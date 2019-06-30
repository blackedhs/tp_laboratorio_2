using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
		/// <summary>
        /// override de equals
        /// </summary>
        public override bool Equals(object obj)
        {            
            return obj is Universitario;
        }
		/// <summary>
        /// muestra los atributos de un universitario
        /// </summary>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo);
            return sb.ToString();
        }
		/// <summary>
        /// dos universitarios son iguales cuando su dni, legajo y tipo lo son
        /// </summary>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }
		/// <summary>
        /// dos universitarios son distintas cuando su dni, legajo y tipo lo son
        /// </summary>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        protected abstract string ParticiparEnClase();   
		/// <summary>
        /// constructor sin parametros
        /// </summary>	
        public Universitario()
        {
        }
		/// <summary>
        /// constructor base universitario
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

    }
}
