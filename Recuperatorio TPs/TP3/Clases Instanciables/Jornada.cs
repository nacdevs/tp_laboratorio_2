using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada:Texto
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public Universidad.EClases Clase { get => clase; set => clase = value; }
        public Profesor Instructor { get => instructor; set => instructor = value; }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Jornada() {
            alumnos = new List<Alumno>();
            instructor = new Profesor();
        }
        /// <summary>
        /// Constructo de instancia con parametros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        /// <summary>
        /// Guarda la jornada pasada por parametro como un txt en el escritorio
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>bool</returns>
        public static bool Guardar(Jornada jornada) {
            Texto txt = new Texto();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txt.Guardar(path+"/Jornada.txt", jornada.ToString());           
            return true;
        }

        /// <summary>
        /// Leer un texto en el escritorio de la maquina, y devuelve un string
        /// </summary>
        /// <returns>string</returns>
        public static string Leer() {
            Texto txt = new Texto();
            string data;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txt.Leer(path + "/Jornada.txt", out data);
            return data;
        }

        /// <summary>
        /// Valida que el alumno no este en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a) {
            return !(j == a);
        }

        /// <summary>
        /// Valida que el alumno este en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega el alumno a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }


        /// <summary>
        /// Sobrecarga de ToString para mostrar los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR NOMBRE COMPLETO: {1}, {2}", this.clase, this.instructor.Apellido, this.instructor.Nombre);
            sb.AppendFormat("\nNACIONALIDAD:{0}\n\n", this.instructor.Nacionalidad);
            foreach(Alumno alumno in alumnos)
            {  
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine(this.clase.ToString());
            sb.AppendLine(this.instructor.ToString());

            sb.AppendLine("<--------------------------------------->");

            return sb.ToString();
        }
    }
}
