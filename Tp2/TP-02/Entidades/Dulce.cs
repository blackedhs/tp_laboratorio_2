using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// instancia un objeto Dulce con los valores de los paramatros
        /// </summary>
        /// <param name="marca">marca del prosucto</param>
        /// <param name="codigo">codigo de barras</param>
        /// <param name="color">color del empaque</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        /// <summary>
        /// Expone todos los atributos de Dulce
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS :"+this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
