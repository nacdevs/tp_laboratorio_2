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

        public Universitario() {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni, nacionalidad) {
            this.legajo = legajo;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected virtual string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Legajo: {0}", this.legajo);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator !=(Universitario pg1, Universitario pg2) {
            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                return false;
            }
            else {
                return true;
            }
        }

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
