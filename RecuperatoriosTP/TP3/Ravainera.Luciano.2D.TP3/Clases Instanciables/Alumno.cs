using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Clases_Instanciables;

namespace Clases_Instanciables
{
    public class Alumno :Universitario
    {
        public enum EEstadoCuenta { AlDia, Becado, Deudor }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            if (this.estadoCuenta == EEstadoCuenta.AlDia)
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            else
                sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);

            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                aux = true;
            }

            return aux;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

    }
}
