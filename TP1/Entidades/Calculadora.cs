using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public Calculadora() { }
        /// <summary>
        /// Valida el operador pasado por parametro y si es incorrecto devuelve +
        /// </summary>
        /// <param name="operador">operador</param>
        /// <returns>string operador validad o + por default</returns>
        private static string ValidarOperador(string operador)
        {
            string ret = null;
            switch (operador)
            {
                case "+":
                    ret = "+";
                    break;

                case "-":
                    ret = "-";
                    break;

                case "*":
                    ret = "*";
                    break;

                case "/":
                    ret = "/";
                    break;

                default:
                    ret = "+";
                    break;
            }

            return ret;
        }
        /// <summary>
        /// Realiza la operacion solicitada con 2 numeros y operador pasados por parametros
        /// </summary>
        /// <param name="num1">numero1</param>
        /// <param name="num2">numero2</param>
        /// <param name="operador">operador</param>
        /// <returns>Devuelve double con el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double ret=0;
            string op = ValidarOperador(operador);
            switch (op)
            {
                case "+":
                    ret = num1 + num2;
                    break;

                case "-":
                    ret = num1 - num2;
                    break;

                case "*":
                    ret = num1 * num2;
                    break;

                case "/":                    
                    ret = num1 / num2;                                   
                    break;


            }

            return ret;
        }
    }
}
