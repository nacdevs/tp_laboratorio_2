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

        public Jornada() {
            alumnos = new List<Alumno>();
            instructor = new Profesor();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        
        public static bool Guardar(Jornada jornada) {
            Texto txt = new Texto();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txt.Guardar(path+"/Jornada.txt", jornada.ToString());           
            return true;
        }

        public static string Leer() {
            Texto txt = new Texto();
            string data;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txt.Leer(path + "/Jornada.txt", out data);
            return data;
        }

        public static bool operator !=(Jornada j, Alumno a) {
            if (j.alumnos.Contains(a))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            if (j.alumnos.Contains(a))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j.alumnos.Contains(a))
            {
                return j;
            }
            else {
                j.alumnos.Add(a);
                return j;

            }
        }

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
