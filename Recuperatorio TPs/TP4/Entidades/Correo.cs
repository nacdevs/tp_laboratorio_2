using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
   public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

       public List<Paquete> Paquetes { get => paquetes; set => paquetes = value; }

        public Correo() {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public void FinEntregas() {
            foreach (Thread thread in mockPaquetes) {
                thread.Abort();
            }
        }

      

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            List<Paquete> paquetes = ((Correo)elemento).paquetes;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in paquetes) {                
                sb.AppendFormat("\n{0} para {1} ({2})\n", paquete.TrackingID,paquete.DireccionEntrega,paquete.Estado.ToString());
            }
            return sb.ToString();
        }

      

        public static Correo operator +(Correo c, Paquete p) {
            foreach (Paquete paquete in c.paquetes) {
                if (paquete == p) {
                    throw new TrackingIdRepetidoException("El paquete esta repetido\n");                    
                }
            }
            c.paquetes.Add(p);
            Thread thread;
            try
            {
                thread = new Thread(p.MockCicloDeVida);
            }
            catch (SqlException sqle) {
                throw sqle;
            }
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
            
        }
    }
}
