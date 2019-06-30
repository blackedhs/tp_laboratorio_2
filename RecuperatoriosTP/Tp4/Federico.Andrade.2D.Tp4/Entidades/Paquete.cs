using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;
        /// <summary>
        /// propiedades de las instancias de paquetes
        /// </summary>
        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }

        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }
        /// <summary>
        /// muestra los datos de una instacia paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} para {1}\n", TrackingID, DireccionEntrega);
            return sb.ToString();
        }
        /// <summary>
        /// modifica los estados del paquetes hasta q sea entregado y guarda sus datos en el DB
        /// </summary>
        public void MockCicloDeVida()
        {
            for (int i = 0; i < 3; i++)
            {
                Estado = (EEstado)i;
                InformaEstado(this, new EventArgs());
                Thread.Sleep(4000);

            }
            PaqueteDAO sql = new PaqueteDAO();
            sql.Insetar(this);
        }
        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }
        /// <summary>
        /// Dos paquetes serán distintos siempre y cuando su Tracking ID sea distinto
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// constructor de instacia
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trinckingID"></param>
        public Paquete(string direccionEntrega, string trinckingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trinckingID;
        }
        /// <summary>
        /// override de tostring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
