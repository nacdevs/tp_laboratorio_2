using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Nestor Camela del curso 2°D";
            this.CenterToScreen();
        }
     

        String[] data = new String[] { "+", "-", "*", "/" };
        public static double Operar(string numero1, string numero2, string operador) {
            double ret = 0;
            Numero num1 = new Numero();
            num1.SetNumero(numero1);

            Numero num2 = new Numero();
            num2.SetNumero(numero2);

            ret=Calculadora.Operar(num1, num2, operador);                       
         
            return ret;
        }

        public void Limpiar() {
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text.ToString();
            string numero2 = txtNumero2.Text.ToString();
            string operador = cmbOperador.Text.ToString();

            lblResultado.Text= Operar(numero1, numero2, operador).ToString();


        }



        private void FormCalculadora_Load(object sender, EventArgs e)
        {

            cmbOperador.Items.AddRange(data);
            cmbOperador.SelectedIndex = 0;
            
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            string res=lblResultado.Text.ToString();
            if (res != null)
            {
                Numero n1 = new Numero();
                lblResultado.Text=n1.DecimalBinario(res);
            }
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string res = lblResultado.Text.ToString();
            if (res != null)
            {
                Numero n1 = new Numero();
                lblResultado.Text = n1.BinarioDecimal(res);
            }

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
            
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
