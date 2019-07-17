using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        String[] data = new String[] { "+", "-", "*", "/" };
        public FormCalculadora()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

       

        /// <summary>
        /// Muesta el resultado de la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text.ToString();
            string numero2 = txtNumero2.Text.ToString();
            string operador = cmbOperador.Text.ToString();

            lblResultado.Text = Operar(numero1, numero2, operador).ToString();
        }
        /// <summary>
        /// Limpia los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }
        /// <summary>
        /// Cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte en binario el resultado en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text.ToString());
        }


        /// <summary>
        /// Convierte en decimal el resultado en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// Realiza la operacion elegida con los numeros y operador dados
        /// </summary>
        /// <param name="numero1">valor numero 1</param>
        /// <param name="numero2">valor numero 2</param>
        /// <param name="operador">valor del operando</param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            double ret = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);

            return ret;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

            cmbOperador.Items.AddRange(data);
            cmbOperador.SelectedIndex = 0;
        }
    }
}
