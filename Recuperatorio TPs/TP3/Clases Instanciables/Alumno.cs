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

        /// <summary>
        /// Constructores de instancia
        /// </summary>
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

        /// <summary>
        /// Muestra datos llamando al metodo ToString
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos() {
            return this.ToString();
        }

        /// <summary>
        /// Verifica que el alumno no participa en una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verifica que el alumno participa en una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrecarga que retorna la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASE DE {0}\n\n\n", claseQueToma.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString que muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
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
