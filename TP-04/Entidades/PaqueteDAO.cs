using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entidades
{
    public static class PaqueteDAO 
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        private static string connectionStr = "Data Source=DESKTOP-L36RL7K; Initial Catalog=correo-sp-2017; Integrated Security=true";



        public static bool Insertar(Paquete p) {
            conexion = new SqlConnection(connectionStr);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            string currentquery = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Nestor Camela 2D')";

            comando.CommandText = currentquery;
            conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException sqle) {
                throw sqle;
            }
               
                
          
           
            return true;
        }

    }
}
