using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero():this(0) {
        }

        public Numero(double numero): this(numero + "")
        {
            
        }

        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }
        /// <summary>
        /// Valida numero pasado como string por parametro
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Devuelve el numero pasado como string en double</returns>
        public double ValidarNumero(string strNumero)
        {
            double ret;
            if (!double.TryParse(strNumero, out ret)) {
                ret = 0;
            }
            return ret;
        }
        /// <summary>
        /// Valida y le asigna a la propiedad numero
        /// </summary>
        /// <param name="numero"></param>
        public void SetNumero(string numero) {
            this.numero = ValidarNumero(numero);
        }

        /// <summary>
        /// Pasa el numero binario pasado por parametro como string a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Devuelve string del numero decimal</returns>
        public static string BinarioDecimal(string binario) {
            string ret="Valor invalido";
            int n;
            if(int.TryParse(binario, out n))
            {
                ret = Convert.ToInt32(binario, 2).ToString();
            }
                
            return ret;
        }
        /// <summary>
        /// Convierte un double decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Devuelve binario en formato string</returns>
        public static string DecimalBinario(double numero) {
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

        public static string DecimalBinario(string numero) {
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
