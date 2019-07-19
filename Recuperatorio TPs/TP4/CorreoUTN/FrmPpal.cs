using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace CorreoUTN
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        private List<Paquete> ingresadosList;
        private List<Paquete> enViajeList;
        private List<Paquete> entregadoList;

        /// <summary>
        /// Constructor del form, inicializa correo y listas 
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            ingresadosList = new List<Paquete>();
            enViajeList = new List<Paquete>();
            entregadoList = new List<Paquete>();

            ingresadoListBox.DataSource = ingresadosList;            
            enViajeListBox.DataSource = enViajeList;
            entregadoListBox.DataSource = entregadoList;

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Agrega un nuevo paquete a la instancia correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete currentPaq = new Paquete(this.direccionTxtBox.Text.ToString(), this.trackingIDTxtBox.Text.ToString());
            currentPaq.Estado = Paquete.EEstado.Ingresado;
            currentPaq.InformaEstado += paq_InformaEstado;
            PaqueteDAO.ExceptionDAO += new ExceptionDelegate(ErrorSQL);
            try
            {
                correo = correo + currentPaq;
                direccionTxtBox.Text = "";
                trackingIDTxtBox.Text = "";
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException exception) {                
               MessageBox.Show("Pedido Repetido!!\n"+exception.Message);                             
            }
            
           
        }


        /// <summary>
        /// Muestra todos los paquetes en el richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo); 
        }

        /// <summary>
        /// Actualiza los listbox mostrando los paquetes que contienen
        /// </summary>
        private void ActualizarEstados() {
            foreach (Paquete paq in correo.Paquetes) {
                switch (paq.Estado) {
                    case Paquete.EEstado.Ingresado:
                        ingresadosList.Remove(paq);
                        ingresadosList.Add(paq);
                        break;
                    case Paquete.EEstado.EnViaje:   
                        enViajeList.Add(paq);
                        ingresadosList.Remove(paq);
                        break;
                    case Paquete.EEstado.Entregado:
                        enViajeList.Remove(paq);
                        entregadoList.Remove(paq);                     
                        entregadoList.Add(paq);                 
                        break;
                }
            }
            ingresadoListBox.DataSource = null;
            ingresadoListBox.DataSource = ingresadosList;

            enViajeListBox.DataSource = null;
            enViajeListBox.DataSource = enViajeList;

            entregadoListBox.DataSource = null;
            entregadoListBox.DataSource = entregadoList;

        }



        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }


        /// <summary>
        /// Muestra la informacion de todos los paquetes y los guarda en un archivo txt
        /// Muestra un mensaje en caso de no poder guardar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento) {          
            if (elemento != null)
            {
                this.mostrarRTxtBox.Text = elemento.MostrarDatos(elemento);
                try
                {
                    mostrarRTxtBox.Text.Guardar("salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al guardar en archivo");
                }
            }


        }

        /// <summary>
        /// Al cerrar el formulario se finalizan todos los hilos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Muestra informacion de un paquete en la lista de entregados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)entregadoListBox.SelectedItem);
        }

        /// <summary>
        /// Muestra mensaje de error si se lanza una sql exception
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="ex"></param>
        private void ErrorSQL(string msj, Exception ex)
        {
            MessageBox.Show(msj + ex.Message);
        }
    }
}
