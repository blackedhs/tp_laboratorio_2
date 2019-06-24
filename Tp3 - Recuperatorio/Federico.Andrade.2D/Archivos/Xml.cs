using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF8);
            bool ret = false;
            try
            {
                ser.Serialize(writer, datos);
                ret = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                writer.Close();
            }
            return ret;
        }

        public bool Leer(string archivo, out T  datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = new XmlTextReader(archivo);
            bool ret = false;
            try
            {
                datos = (T)ser.Deserialize(reader);
                ret = true;
            }
            catch (Exception e )
            {
                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }            
            return ret;
        }
    }
}
