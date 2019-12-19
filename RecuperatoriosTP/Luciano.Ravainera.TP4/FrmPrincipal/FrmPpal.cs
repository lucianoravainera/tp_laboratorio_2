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

namespace FrmPrincipal
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            PaqueteDAO.eventoPaqueteDAO += this.ErrorSql;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Si se produce un cambio de estado, actualizo todos los estados de los paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
                this.ActualizarEstados();
        }

        /// <summary>
        /// Al cerrarse el formulario, termino todos los hilos en ejecución.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Comprueba y actualiza los estados de envio de los paquetes,
        /// colocando cada paquete en el ListBox correspondiente.
        /// </summary>
        private void ActualizarEstados()
        {
            // Limpio las listas
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }
        /// <summary>
        /// Lanza el error por MessageBox al conectarse a la DB
        /// </summary>
        /// <param name="mensaje"></param>
        private void ErrorSql(string mensaje)
        {
            MessageBox.Show(mensaje, "ERROR AL CONECTARSE A LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Mostrará la información del elemento en RichTextBox rtbMostrar
        /// y utilizará el método de extensión para guardar el texto en this.rtbMostrar.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    this.rtbMostrar.Text.Guardar("Salida.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error de archivo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        /// <summary>
        /// Muestro la información de un paquete en particular de la lista de Entregados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
