using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Entidades
{
    public class PaqueteDAO
    {
        private SqlCommand comando;
        private SqlConnection conexion;
        public PaqueteDAO()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
        }
        /// <summary>
        /// guarda los datos de los paquetes en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Insetar(Paquete p)
        {
            string query = $"INSERT INTO direccionEntrega = {p.DireccionEntrega} , alumno = Federico.Andrade " +
                $", trackingID = {p.TrackingID} FROM PK_Paquetes";
            try
            {
                conexion.Open();
                comando = new SqlCommand(query, conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                     return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
