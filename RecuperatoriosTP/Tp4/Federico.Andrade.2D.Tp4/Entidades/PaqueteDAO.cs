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
        /// <summary>
        /// evento para manejar errores en la base de datos
        /// </summary>
        public static event DelegadoException ExceptionDao;
        private SqlCommand comando;
        private SqlConnection conexion;
        /// <summary>
        /// Constructor de instancia del paqueteDAO, instancia el atributo de conexion
        /// </summary>
        public PaqueteDAO()
        {
            try
            {
                conexion = new SqlConnection("Data Source=.;Initial Catalog=correo-sp-2017;Integrated Security=True");
                conexion.Open();
            }
            catch (Exception ex)
            {
               ExceptionDao("Error, Problema de coneccion con la base de datos",ex);
            }
        }
        /// <summary>
        /// guarda los datos de los paquetes en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Insetar(Paquete p)
        {
            string query = "INSERT INTO dbo.Paquetes (direccionEntrega,alumno,trackingID) values ('" + p.DireccionEntrega+"','Federico.Andrade',"+p.TrackingID+")";
            try
            {                
                comando= new SqlCommand(query , conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                     return true;
                }
                return false;
            }            
            catch (Exception ex)
            {                
                ExceptionDao("Error, al insertar en la base de datos " , ex);
                return false;
            }
            finally
            {
               conexion.Close();
            }
        }
    }
}
