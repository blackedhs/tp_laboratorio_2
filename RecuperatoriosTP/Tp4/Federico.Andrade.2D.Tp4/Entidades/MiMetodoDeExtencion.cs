using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class MiMetodoDeExtencion
    {
        /// <summary>
        /// Crea un método de extensión para la clase String.
        /// Este guardará en un archivo de texto en el escritorio de la máquina
        /// Si el archivo existe, agregará información en él.
        /// </summary>
        /// <param name="texto">texto a agregar</param>
        /// <param name="archivo">nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = String.Format("{0}\\{1}", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), archivo);
            try
            {
                using (StreamWriter st = new StreamWriter(path, true))
                st.WriteLine(texto);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
