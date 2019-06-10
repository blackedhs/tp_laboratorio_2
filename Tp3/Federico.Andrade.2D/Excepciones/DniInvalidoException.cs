using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public  class DniInvalidoException: Exception
    {
        private string mesajeBase;
        public DniInvalidoException(string message,Exception e)
        {

        }
        public DniInvalidoException(Exception e)
        {

        }
        public DniInvalidoException(string message)
        {

        }
        public DniInvalidoException()
        {

        }
    }
}
