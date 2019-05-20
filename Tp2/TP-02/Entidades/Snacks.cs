using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// instancia un objeto Snack con los valores de los paramatros
        /// </summary>
        /// <param name="marca">marca del prosucto</param>
        /// <param name="codigo">codigo de barras</param>
        /// <param name="color">color del empaque</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color): base(codigo, marca, color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        /// <summary>
        /// Expone todos los atributos de Dulce
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : "+ this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
