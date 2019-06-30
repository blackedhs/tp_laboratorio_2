using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
		/// <summary>
        /// propiedades de persona
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (this.ValidarNombreApellido(value) == 1)
                {
                    nombre=value;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }
        public int DNI
        {
            get { return dni; }
            set
            {
                if (this.ValidarDni(this.nacionalidad, value) == 1)
                    dni = value;
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (this.ValidarNombreApellido(value) == 1)
                {
                    apellido = value;
                }
            }
        }
        public string StringToDNI
        {
            set
            {
                int dni;
                if (ValidarDni(this.nacionalidad, value) == 1)
                {
                    int.TryParse(value, out dni);
                    DNI = dni;
                }
            }
        }
		/// <summary>
        /// constructor sin parametros
        /// </summary>
        public Persona()
        {
        }
		/// <summary>
        /// constructor base de persona
        /// </summary>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }
		/// <summary>
        /// constructor base de persona
        /// </summary>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
		/// <summary>
        /// constructor base de persona
        /// </summary>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            StringToDNI = dni;
        }
		/// <summary>
        /// muestra los datos de persona
        /// </summary>
        public new virtual string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre: " + this.nombre);
            sb.AppendLine("Apellido: " + this.apellido);
            sb.AppendLine("DNI: " + this.dni);
            sb.AppendLine("Nacionalidad: " + this.nacionalidad);
            return sb.ToString();
        }
		/// <summary>
        /// valida si el dni esta dentro de los parametros segun nacionalidad
        /// </summary>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 99999999)
                throw new DniInvalidoException("DNI invalido");
            if (Nacionalidad == ENacionalidad.Argentino && dato > 1 && dato < 89999999
                || Nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
                return 1;
            else
                throw new NacionalidadInvalidaException("La Nacionalidad no se condice con el numero de DNI");
        }
		/// <summary>
        /// valida que los datos ingresados sean correctos para un nombre o apellido
        /// </summary>
        private int ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            // Valido el dato
            Match match = regex.Match(dato);

            if (match.Success)
                return 1;
            else
                return 0;

        }
		/// <summary>
        /// valida si el dni esta dentro de los parametros segun nacionalidad
        /// </summary>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (dato.Length > 8 || dato.Length < 1 || int.TryParse(dato, out dni) == false)
                throw new DniInvalidoException("DNI invalido");
            else
                return 1;
        }
    }
}
