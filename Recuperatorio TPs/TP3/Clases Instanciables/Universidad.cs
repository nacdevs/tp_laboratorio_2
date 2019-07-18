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

        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public List<Jornada> Jornadas { get => jornadas; set => jornadas = value; }
        public List<Profesor> Instructores { get => profesores; set => profesores = value; }

        public Jornada this[int i] {
            get { return jornadas[i]; }
            set { jornadas[i] = value; }
        }

        /// <summary>
        /// Crea la instancia de Universidad
        /// </summary>
        public Universidad() {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornadas = new List<Jornada>();
        }

        /// <summary>
        /// Guarda la universidad pasada por parametro en un XML en el escritorio
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni) {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(path+"/Universidad.xml", uni);

        }

       
        /// <summary>
        /// Lee el archivo que se encuentra en el escritorio
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static Universidad Leer(string archivo) {
            Universidad uni = new Universidad();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(path+"/Universidad.xml", out uni);
            return uni;  
        }
        /// <summary>
        /// Muestra los datos de la Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrecarga metodo ToString y llama al metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        
        public static bool operator !=(Universidad g, Alumno a) {
            return !(g == a);

        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
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

        /// <summary>
        /// Agrega una jornada a la universidad pasada por parametro
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Agrega un alumno a la universidad pasada por parametro
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
                return g;
            }
            throw new AlumnoRepetidoException();    
        }

        /// <summary>
        /// Agrega un profesor a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
          
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }


        /// <summary>
        /// Valida que una universidad contenga a un alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {  
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Validad que una universidad contenga a un profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
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
