using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
		///Excepcion alumno repetido
        public AlumnoRepetidoException():base("Alumno repetido")
        {
        }
    }
}
