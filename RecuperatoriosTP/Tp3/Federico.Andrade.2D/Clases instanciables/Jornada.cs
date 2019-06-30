using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
		/// <summary>
        /// propiedades
        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }
		/// <summary>
        /// constructor sin params
        /// </summary>
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
		/// <summary>
        /// constructor de instancia
        /// </summary>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
		/// <summary>
        /// lee los datos de un archivo y los devuelve en un string
        /// </summary>
        public static string Leer()
        {
            Texto txt = new Texto();
            string dato;
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            txt.Leer(path, out dato);
            return dato;
        }
		/// <summary>
        /// una jornada es igual a un alumno cuando el alumno esta en la lista de alumnos de jornada
        /// </summary>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
		/// <summary>
        /// una jornada es distinta a un alumno cuando el alumno no esta en la lista de alumnos de jornada
        /// </summary>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
		/// <summary>
        /// agrega un alumno a una jornada si no esta en la lista
        /// </summary>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }
		/// <summary>
        /// espone los datos de la clase jornada y su lista de alumnos
		/// <summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE : "+this.clase);
            sb.AppendLine("PROFESOR: "+this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------------------->");
            return sb.ToString();
        }
		/// <summary>
        /// guarda los datos de la jornada en un archivo de texto
		/// <summary>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            bool ret = false;
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            txt.Guardar(path, jornada.ToString());
            ret = true;          
            return ret;
        }
    }
}
