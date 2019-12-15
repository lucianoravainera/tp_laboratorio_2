using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete :IMostrar<Paquete> //el tipo generico es Paquete
    {
        public delegate void DelegadoEstado(Object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Enumerado con los estados del paquete (dentro de clase Paquete)
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #region Contructores
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            ///"estado" se deberia cargar con el enum 0 "ingresado"
        }
        #endregion
        #region Propiedades
        /// <summary>
        /// Propiedad GET y SET para direccionEntrega 
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Propiedad GET y SET para estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Propiedad GET y SET para trackingID 
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Implementacion del metodo de la interface IMostrar
        /// </summary>
        /// <param name="elemento">paquete</param>
        /// <returns>string con los datos del paquete recibido</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento;
            return String.Format("{0} para {1}", paquete.TrackingID, paquete.direccionEntrega);          
        }
        /// <summary>
        /// metodo que provoca el cambio de estado del paquete (Ingresado > EnViaje > Entregado)
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);// duermo el hilo 4 segundos
                this.estado++; //paso al siguente estado
                this.InformaEstado.Invoke(this, new EventArgs()); // informo el estado
            } while (this.estado != (EEstado)2);
            PaqueteDAO.Insertar(this);//guardo en la DB
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Dos paquetes son iguales si sus trackingID son iguales
        /// </summary>
        /// <param name="p1">paquete 1</param>
        /// <param name="p2">paquete 2</param>
        /// <returns>true si son iguales, false si no coincide su trachingID</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }
        /// <summary>
        /// Dos paquetes no son iguales si sus trackingID no coinciden
        /// </summary>
        /// <param name="p1">paquete 1</param>
        /// <param name="p2">paquete 2</param>
        /// <returns>true si no son iguales, false si son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString devolviendo la informacion del paquete
        /// </summary>
        /// <returns>Informacion del paquete</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this.MostrarDatos(this) + $" estado: {this.estado}");
            return retorno.ToString();
        }
        #endregion
    }
}
