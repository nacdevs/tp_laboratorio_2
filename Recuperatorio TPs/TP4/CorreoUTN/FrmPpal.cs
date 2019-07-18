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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete currentPaq = new Paquete(this.direccionTxtBox.Text.ToString(), this.trackingIDTxtBox.Text.ToString());
            currentPaq.Estado = Paquete.EEstado.Ingresado;
            currentPaq.InformaEstado += paq_InformaEstado;
            try
            {
                correo = correo + currentPaq;
                direccionTxtBox.Text = "";
                trackingIDTxtBox.Text = "";
                ActualizarEstados();
            }
            catch (Exception exception) {
                if (exception is TrackingIdRepetidoException)
                {
                    MessageBox.Show("Pedido Repetido!!\n"+exception.Message);
                }
                else {
                    MessageBox.Show("Exception!!\n"+exception.Message);
                }
                
            }
            
           
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);

        }

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

        private void MostrarInformacion<T>(IMostrar<T> elemento) {
            if (elemento != null) {
                this.mostrarRTxtBox.Text = correo.MostrarDatos((Correo)elemento);
                string salida = correo.MostrarDatos((Correo)elemento);
                salida.Guardar("salida.txt");
            }

            
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }


    }
}
