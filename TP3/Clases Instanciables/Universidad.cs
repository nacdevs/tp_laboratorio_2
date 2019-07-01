using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;
using System.IO;

namespace Clases_Instanciables
{
    public class Universidad : Xml<Universidad>
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        private Universidad uniXml;

        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public List<Jornada> Jornadas { get => jornadas; set => jornadas = value; }
        public List<Profesor> Instructores { get => profesores; set => profesores = value; }

        public Jornada this[int i] {
            get { return jornadas[i]; }
            set { jornadas[i] = value; }
        }


        public Universidad() {
        }


        public static bool Guardar(Universidad uni) {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(path+"/Universidad.xml", uni);

        }

       

        public static Universidad Leer(string archivo) {
            Universidad uni = new Universidad();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(path+"/Universidad.xml", out uni);
            return uni;  
        }

        private string MostrarDatos(Universidad uni) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------JORNADAS-------");
            foreach (Jornada jorn in jornadas)
            {
                sb.Append(jorn.ToString());
            }
            sb.AppendLine("---------ALUMNOS---------");
            foreach (Alumno alumno in alumnos)
                {
                    sb.Append(alumno.ToString());
                }       

            
          
            
                        
                sb.AppendLine("--------INSTRUCTORES--------");
                foreach (Profesor prof in profesores)
                {
                    sb.Append(prof.ToString());
                }           

         

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


        public static bool operator !=(Universidad g, Alumno a) {
            if (g.alumnos.Contains(a))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            if (g.profesores.Contains(i))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor prof in g.profesores)
            {
                if (prof != clase)
                {
                    return prof;
                }
            }
            throw new SinProfesorException();
        }


        public static Universidad operator +(Universidad g, EClases clase) {
                
                Jornada jorn = new Jornada();
                jorn.Clase = clase;
                if (g.jornadas == null) {
                g.jornadas = new List<Jornada>();
                }
                
                foreach (Profesor prof in g.profesores)
                {
                if (prof == clase)
                {
                    jorn.Instructor = prof;
                    
                }
                else {
                    throw new SinProfesorException();
                }
                }

                foreach (Alumno alumno in g.alumnos)
                {
                    if (alumno == clase)
                    {   
                        jorn.Alumnos.Add(alumno);
                   
                    }
                }
                g.jornadas.Add(jorn);
            
            
            return g;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g.alumnos == null)
            {
                g.alumnos = new List<Alumno>();
                g.alumnos.Add(a);
            }
            else {
                foreach (Alumno alumno in g.alumnos) {
                    if (alumno.DNI == a.DNI) {
                        throw new AlumnoRepetidoException();

                    }
                }
                g.alumnos.Add(a);
                
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g.profesores == null)
            {
                g.profesores = new List<Profesor>();
                g.profesores.Add(i);
            }
            else {
           
                if (!g.profesores.Contains(i))
                {
                    g.profesores.Add(i);
                }
            }

            return g;
        }



        public static bool operator ==(Universidad g, Alumno a)
        {
            if (g.alumnos.Contains(a))
            {
                return true;
            }
            else {
                return false;
            }
            
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            if (g.profesores.Contains(i))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            
            foreach (Profesor prof in g.profesores) {            
                if (prof == clase)
                {       
                    return prof;
                }
            }
            throw new SinProfesorException();
            
        }



        public enum EClases {
            Programacion,Laboratorio,Legislacion,SPD
        }
    }
}
