using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario:Persona
    {
        private int legajo;
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Universitario() {
        }
        /// <summary>
        /// Constructor de instancia con parametros
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni, nacionalidad) {
            this.legajo = legajo;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Muestra datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Legajo: {0}", this.legajo);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Verifica que dos universitarios sean distintos 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2) {
            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                return false;
            }
            else {
                return true;
            }
        }

        /// <summary>
        /// Verifica que dos universitarios sean iguales mediante numero de legajo y dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
