using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
    {
        public Calculadora() { }
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
