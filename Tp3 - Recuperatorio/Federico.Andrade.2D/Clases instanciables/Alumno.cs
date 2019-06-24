using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
		/// <summary>
        /// constructor sin parametros
        /// </summary>
        public Alumno()
        {

        }
		/// <summary>
        ///constructor de instancia
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
		/// <summary>
        ///constructor de instancia
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {            
            this.estadoCuenta = estadoCuenta;
        }
		/// <summary>
        /// muestra los datos de alumno y los base de la clase madre
        /// </summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta : " + this.estadoCuenta);
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
		/// <summary>
        /// un alumno es igual a una clase cuando este toma esa clase y tiene la cuota sin deudas
        /// </summary>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
		/// <summary>
        /// un alumno es distinto a una clase cuando este no toma esa clase o tiene la cuota con deudas
        /// </summary>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
		/// <summary>
        ///  muestra la clase q toma un alumno
        /// </summary>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TOMA CLASE DE " + this.claseQueToma);            
            return sb.ToString();
        }
		/// <summary>
        /// espone los datos de mostrarDatos
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.MostrarDatos());
            return sb.ToString();
        }
    }
}
