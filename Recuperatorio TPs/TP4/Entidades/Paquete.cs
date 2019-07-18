using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades
{
    public class Paquete : IMostrar <Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public string DireccionEntrega { get => direccionEntrega; set => direccionEntrega = value; }
        public EEstado Estado { get => estado; set => estado = value; }
        public string TrackingID { get => trackingID; set => trackingID = value; }

        /// <summary>
        /// Constructor de la instancia Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID) {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        /// <summary>
        /// Simula el ciclo de vida de un paquete pasando por distintos estados
        /// </summary>
        public void MockCicloDeVida() {
            while (this.estado != EEstado.Entregado) {
                Thread.Sleep(4000);
                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        this.estado = EEstado.EnViaje;
                        break;

                    case EEstado.EnViaje:
                        this.estado = EEstado.Entregado;
                        break;

                }
                EventArgs args = new EventArgs();
                InformaEstado(this, args);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }



        }
        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\n{0} para {1}", ((Paquete)elemento).trackingID , ((Paquete)elemento).direccionEntrega);
            return "a";
        }
        /// <summary>
        /// Sobrecarga de ToString para mostrar datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Direccion entrega: {0}", this.direccionEntrega);
            sb.AppendFormat("\n Estado: {0}", this.estado);
            sb.AppendFormat("\n Tracking Id: {0}", this.trackingID);
            return sb.ToString();
        }
        /// <summary>
        /// Los paquetes son distintos si el tracking Id es distinto
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2) {
            if (p1.trackingID != p2.trackingID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Los paquetes son iguales si tienen el mismo tracking Id
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.trackingID == p2.trackingID)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public enum EEstado {
            Ingresado,EnViaje,Entregado
        }

    }
}
