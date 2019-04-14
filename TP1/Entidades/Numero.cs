using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        public Numero() {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            
        }

        public Numero(string strNumero)
        {
            
        }

        public double ValidarNumero(string strNumero)
        {
            double ret;
            if (!double.TryParse(strNumero, out ret)) {
                ret = 0;
            }
            return ret;
        }

        public void SetNumero(string numero) {
            this.numero = ValidarNumero(numero);
        }


        public string BinarioDecimal(string binario) {
            string ret="Valor invalido";
            int n;
            if(int.TryParse(binario, out n))
            {
                ret = Convert.ToInt32(binario, 2).ToString();
            }
                
            return ret;
        }

        public string DecimalBinario(double numero) {
            string ret;
            int n;
            if (int.TryParse(numero.ToString(), out n))
            {
                ret = Convert.ToString(n, 2);
            }
            else {
                ret = "Valor invalido";
            }
            
            return ret;
        }

        public string DecimalBinario(string numero) {
            string ret="Valor invalido";
            double n;
            if (double.TryParse(numero, out n)) {
                ret = DecimalBinario(n);
            }           
            return ret;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double ret = n1.numero + n2.numero;
            return ret;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double ret = n1.numero - n2.numero;
            return ret;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double ret = n1.numero * n2.numero;
            return ret;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double ret = 0;
            if (n2.numero != 0) {
                ret = n1.numero / n2.numero;
            }
            else
            {
                ret = double.MinValue;
            }
            
            return ret;
        }


    }
}
