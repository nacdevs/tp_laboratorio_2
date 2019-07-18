using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
namespace Clases_Instanciables
{
    public class Profesor:Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Profesor() {
            clasesDelDia = new Queue<Universidad.EClases>();           
        }
        /// <summary>
        /// Constructor de instancia con parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad) {
            clasesDelDia = new Queue<Universidad.EClases>();
            random = new Random();
            _randomClases();

        }

        /// <summary>
        /// Generea clases random
        /// </summary>
        private void _randomClases() {           
            Universidad.EClases rndClase = (Universidad.EClases)random.Next(Enum.GetNames(typeof(Universidad.EClases)).Length);
            Universidad.EClases rndClase2 = (Universidad.EClases)random.Next(Enum.GetNames(typeof(Universidad.EClases)).Length);
            clasesDelDia.Enqueue(rndClase);
            clasesDelDia.Enqueue(rndClase2);
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Profesor");
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga que agrega las clases del dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nCLASES DEL DIA");
            foreach (Universidad.EClases clase in clasesDelDia) {
                sb.AppendLine(clase.ToString());
            }
            sb.AppendLine("\n");
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga de ToString() que llama al metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Valida que el profesor tenga clases en la universidad
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases clases in i.clasesDelDia)
            {
                if (clases == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase) {
            return !(i == clase);
        }

    }
}
