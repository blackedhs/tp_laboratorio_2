using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
		/// <summary>
        /// enum de clases
		/// <summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
		/// <summary>
        /// propiedades
		/// <summary>
        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }
        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get { return jornadas; }
            set { jornadas = value; }
        }
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }
		/// <summary>
        /// lee un archivo xml y genera un objeto universidad con esos datos
		/// <summary>
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad g = new Universidad();
            string path = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            xml.Leer(path, out g);
            return g;
        }
		/// <summary>
        /// guarada en un archivo xml, los datos una universidad con sus datos
		/// <summary>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool ret = false;
            string path = String.Format("{0}\\Universidad.xml",Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) ;
            ret = xml.Guardar(path, uni);
            return ret;
        }
		/// <summary>
        /// una univerdidad es distinta a un alumno cuando el alumno no esta en la lista de alumnos
		/// <summary>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
		/// <summary>
        /// una univerdidad es distinta a un profesor cuando el profesor no esta en la lista de alumnos
		/// <summary>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
		/// <summary>
        /// devuelve un profesor q no dicte esa clase, de no haber lanza una excepcion
		/// <summary>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
		/// <summary>
        /// una univerdidad es igual a un alumno cuando el alumno esta en la lista de alumnos
		/// <summary>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
		/// <summary>
        /// una univerdidad es igual a un profesor cuando el profesor esta en la lista de alumnos
		/// <summary>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }
		/// <summary>
        /// devuelve un profesor q dicte esa clase, de no haber lanza una excepcion
		/// <summary>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
		/// <summary>
        /// agrega un alumno a una univerdidad, si ya se encuentra lanza una excepcion
		/// <summary>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
                return g;
            }
            throw new AlumnoRepetidoException();
        }
		/// <summary>
        /// agrega un profesor a una univerdidad, si ya se encuentra lanza una excepcion
		/// <summary>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }
		/// <summary>
        /// agrega una clase a una univerdidad y un profesor que pueda darla 
		/// <summary>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g==clase);
            g.jornadas.Add(jornada);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            return g;
        }
		/// <summary>
        /// espone los datos de la univerdidad
		/// <summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MostrarDatos(this));            
            return sb.ToString();
        }
		/// <summary>
        ///constructor de instancia
		/// <summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornadas = new List<Jornada>();
        }
		/// <summary>
        /// espone los datos de la univerdidad
		/// <summary>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADAS: ");            
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }            
            return sb.ToString();
        }

    }
}
