using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        // Evento y delegado usado para informar al usuario en caso de error en DB
        public delegate void DelegadoPaqueteDAO(string mensaje);
        public static event DelegadoPaqueteDAO eventoPaqueteDAO;

        private static SqlConnection conexion;
        private static SqlCommand comando;

        #region Contructores
        /// <summary>
        /// Constructor estatico 
        /// </summary>
        static PaqueteDAO()
        {
            //datos para la coneccion con la DB 
            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog =correo-sp-2017; Integrated Security = True";
            PaqueteDAO.conexion = new SqlConnection(connStr);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo que guarda en la DB los paquetes
        /// </summary>
        /// <param name="p">paquete a guardar</param>
        /// <returns>true si guardo, false si hubo un error</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = true;           
            try
            {
                comando.CommandText = $"INSERT INTO dbo.Paquetes "+$"(direccionEntrega, trackingID, alumno ) "+$"VALUES ('{p.DireccionEntrega}', '{p.TrackingID}', 'Ravainera')";
                PaqueteDAO.conexion.Open();// abro conexion
                PaqueteDAO.comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                retorno = false;
                eventoPaqueteDAO.Invoke(e.Message);
            }
            finally
            {
                PaqueteDAO.conexion.Close(); // cierro la conexion con la DB
            }
            return retorno;
        }
        #endregion

    }
}
