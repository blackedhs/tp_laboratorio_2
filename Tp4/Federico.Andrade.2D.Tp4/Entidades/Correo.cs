using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
        /// <summary>
        /// constructor de la instancia correo
        /// </summary>
        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }
        /// <summary>
        /// cierra todos los hilos del correo
        /// </summary>
        public void finEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                hilo.Abort();
            }
        }
        /// <summary>
        /// muestra los datos de los paquetes que contiene el correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n", paquete.TrackingID,
                    paquete.DireccionEntrega, paquete.Estado.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// agrega un nuevo paquete y genera un nuevo ciclo de vida en un nuevo hilo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("Tracking ID repetido");
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
    }
}
