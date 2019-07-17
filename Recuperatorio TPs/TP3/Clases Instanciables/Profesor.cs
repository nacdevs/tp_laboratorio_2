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

        
        public Profesor() {
            clasesDelDia = new Queue<Universidad.EClases>();
      
           
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad) {
            clasesDelDia = new Queue<Universidad.EClases>();
            random = new Random();
            _randomClases();

        }


        private void _randomClases() {           
            Universidad.EClases rndClase = (Universidad.EClases)random.Next(Enum.GetNames(typeof(Universidad.EClases)).Length);
            Universidad.EClases rndClase2 = (Universidad.EClases)random.Next(Enum.GetNames(typeof(Universidad.EClases)).Length);
            clasesDelDia.Enqueue(rndClase);
            clasesDelDia.Enqueue(rndClase2);
        }

        protected override string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Profesor");
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase) {
            if (i.clasesDelDia.Contains(clase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
