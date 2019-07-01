using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno() {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad){
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos() {
            return this.ToString();
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase) {
            if (a.claseQueToma == clase && ((a.estadoCuenta == EEstadoCuenta.AlDia) || (a.estadoCuenta == EEstadoCuenta.Becado)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && ((a.estadoCuenta == EEstadoCuenta.AlDia) || (a.estadoCuenta == EEstadoCuenta.Becado)))
            {
                return true;
            }
            else {
                return false;
            }
        }

        protected override string ParticiparEnClase() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASE DE {0}\n\n\n", claseQueToma.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Alumno");
            sb.AppendLine(base.MostrarDatos());
            sb.Append(ParticiparEnClase());
            return sb.ToString();
        }

        public enum EEstadoCuenta {
            AlDia,Deudor,Becado
        }
    }
}
