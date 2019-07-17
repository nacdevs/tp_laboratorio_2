using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string Apellido { get => apellido; set => apellido = value; }
        public ENacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public int DNI {
            get { 
             return dni; }
            set {
                switch (Nacionalidad) {
                    case ENacionalidad.Argentino:
                        if (value > 1 && value < 89999999)
                        {
                            dni = value;
                        }
                        else {
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                                }
                        break;
                    case ENacionalidad.Extranjero:
                        if (value > 90000000 && value < 99999999)
                        {
                            dni = value;
                        }
                        else {
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                        }
                        break;
                }
            }
        }
       
        public string Nombre { get => nombre; set {
                int wNom;
                if (Int32.TryParse(value, out wNom))
                {

                }
                else {
                    nombre = value;
                }
            } }
        public string StringToDNI{ set {
                int wDni;
                if (Int32.TryParse(value, out wDni))
                {
                   DNI = wDni;
                }
                else {
                    throw new DniInvalidoException("Dni Invalido");
                }
                
            } }



        public Persona() { }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0}\n", this.nombre);
            sb.AppendFormat("Apellido: {0}\n", this.apellido);
            sb.AppendFormat("Dni: {0}\n", this.dni);
            sb.AppendFormat("Nacionalidad: {0}", this.nacionalidad);

            return sb.ToString();

        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato) {
            return 1;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 1;
        }

        private string ValidarNombreApellido(string dato) {
            return "a";
        }


        public enum ENacionalidad {
            Argentino,Extranjero
        }
    }
}
