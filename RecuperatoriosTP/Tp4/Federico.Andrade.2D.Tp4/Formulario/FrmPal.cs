using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace Formulario
{
    public partial class FrmPal : Form
    {
        private Entidades.Correo correo;
        /// <summary>
        /// constructor del form inicializa el atriburo correo
        /// </summary>
        public FrmPal()
        {
            InitializeComponent();
            correo = new Entidades.Correo();
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// agrega un nuevo paquete a la instancia correo 
        /// muestra un msj si no pudo agregarse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            try
            {
                correo += p;
                p.InformaEstado += new Paquete.DelegadoEstado(Paq_InformaEstado);
                PaqueteDAO.ExceptionDao += new DelegadoException(ErrorDAO);
            }
            catch (TrackingIdRepetidoException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// actualiza los listbox mostrando los paquetes q contiene cada uno
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }

            }
        }
        /// <summary>
        /// muestra la informacion de todos los paquetes y los guarda en un archivo
        /// muestra un mensaje si no puede guardarse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al guardar en archivo");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(this.Paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        /// <summary>
        /// el cerrar el formulario cierra todos los hilos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
        /// <summary>
        /// muestra todos los paquetes generados en el rich del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// muestra un msj de error en la base de datos.
        /// </summary>
        /// <param name="msj">msj escrito</param>
        /// <param name="ex">msj de la exception</param>
        private void ErrorDAO(string msj,Exception ex)
        {
            MessageBox.Show(msj + ex.Message);
        }
    }
}
