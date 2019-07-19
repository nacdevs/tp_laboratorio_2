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
        public static event ExceptionDelegate ExceptionDAO;



        static PaqueteDAO()
        {              
            string connectionStr = "Data Source=DESKTOP-L36RL7K; Initial Catalog=correo-sp-2017; Integrated Security=true";
            conexion = new SqlConnection(connectionStr);
        }

        /// <summary>
        /// Guarda los datos del paquete en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p) {
            bool ret = false;
            comando = new SqlCommand();          
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                string currentquery = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Nestor Camela 2D')";
                comando = new SqlCommand(currentquery, conexion);
                comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException sqle) {
                ExceptionDAO("Error al insertar en base de datos: ", sqle);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }             
            return ret;
        }

    }
}
