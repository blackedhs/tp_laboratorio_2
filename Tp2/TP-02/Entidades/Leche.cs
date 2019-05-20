using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : this(marca, codigo, color, ETipo.Entera)
        {
        }
        /// <summary>
        /// instancia un objeto Leche con los valores de los paramatros
        /// </summary>
        /// <param name="marca">marca del prosucto</param>
        /// <param name="codigo">codigo de barras</param>
        /// <param name="color">color del empaque</param>
        /// <param name="tipo">tipo de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color,ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// Expone todos los atributos de leche
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : "+ this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
