using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;
namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Getter y Setter de apellido, y valida llamando al metodo ValidarNombreApellido
        /// </summary>
        public string Apellido { get => apellido; set {
                if (this.ValidarNombreApellido(value) == 1)
                {
                    apellido = value;
                }
            }
        }
        /// <summary>
        /// Getter y setter de nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }


        /// <summary>
        /// Getter y Setter de dni, y valida llamando al metodo ValidarDni
        /// </summary>
        public int DNI {
            get { 
             return dni; }
            set {
                if (this.ValidarDni(this.nacionalidad, value) == 1)
                    dni = value;
             
            }
        }
       /// <summary>
       /// Getter y setter de nombre, y valida llamando al metodo ValidarNombreApellido
       /// </summary>
        public string Nombre { get => nombre; set {
                if (this.ValidarNombreApellido(value) == 1)
                {
                    nombre = value;
                }
            } }

        /// <summary>
        /// Setter del valor dni, recibe un string y lo valida como dni con el metodo ValidarDni
        /// </summary>
        public string StringToDNI{ set {
                int dni;
                if (ValidarDni(this.nacionalidad, value) == 1)
                {
                    int.TryParse(value, out dni);
                    DNI = dni;
                }

            } }


        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de instancia con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.DNI= dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }


        /// <summary>
        /// Sobrecarga del metodo to string, para mostra los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0}\n", this.nombre);
            sb.AppendFormat("Apellido: {0}\n", this.apellido);
            sb.AppendFormat("Dni: {0}\n", this.dni);
            sb.AppendFormat("Nacionalidad: {0}", this.nacionalidad);

            return sb.ToString();

        }
        

        /// <summary>
        /// Valida el dni pasado por parametro
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato) {
            if (dato > 99999999)
                throw new DniInvalidoException("DNI no valido");
            if (Nacionalidad == ENacionalidad.Argentino && dato > 1 && dato < 89999999
                || Nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
                return 1;
            else
                throw new NacionalidadInvalidaException("La Nacionalidad no se condice con el numero de DNI");
        }


        /// <summary>
        /// Valida que el string pasado por parametro sea un dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (dato.Length > 8 || dato.Length < 1 || int.TryParse(dato, out dni) == false)
                throw new DniInvalidoException("DNI invalido");
            else
                return 1;
        }

        /// <summary>
        /// Valida el nombre o apellido pasado por parametro, mediante regular expression
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarNombreApellido(string dato) {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);

            if (match.Success)
                return 1;
            else
                return 0;
            
        }


        public enum ENacionalidad {
            Argentino,Extranjero
        }
    }
}
