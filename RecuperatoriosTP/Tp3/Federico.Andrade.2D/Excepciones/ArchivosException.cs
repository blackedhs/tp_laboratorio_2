﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException: Exception
    {
		///Excepcion problemas con archivos
        public ArchivosException(Exception innerException):base("Error,Problema al prosesar un archivo",innerException)
        {            
        }
    }
}