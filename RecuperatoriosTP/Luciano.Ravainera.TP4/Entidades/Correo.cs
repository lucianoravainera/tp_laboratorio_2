using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo :IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Constructores
        /// <summary>
        /// Constructor por defecto estatico en donde inicializo ambas listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion
        #region Propiedades
        /// <summary>
        /// Propiedad GET y SET para Paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Retorna los datos de todos los paquetes de la lista recibidos.
        /// </summary>
        /// <param name="elementos">interface con la lista</param>
        /// <returns>string con los datos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            Correo C = (Correo)elementos;
            string retorno = "";
            foreach (Paquete p in C.paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID,p.DireccionEntrega,p.Estado.ToString());
            }
            return retorno;
        }
        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        #endregion
        #region Operadores
        /// <summary>
        /// Agrega un paquete a la lista "paquetes" en Correo
        /// </summary>
        /// <param name="C">correo</param>
        /// <param name="p">paquete</param>
        /// <returns>el Correo con el paquete agrergado</returns>
        public static Correo operator +(Correo C, Paquete p)
        {
            foreach (Paquete item in C.paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El trackingID esta repetido");
                }
            }
            C.paquetes.Add(p);
            Thread HiloMockCicloDeVida = new Thread(p.MockCicloDeVida);
            C.mockPaquetes.Add(HiloMockCicloDeVida);
            HiloMockCicloDeVida.Start();
            return C;
        }
        #endregion

    }
}
