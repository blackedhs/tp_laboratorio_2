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

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }
        public Jornada this[int i]
        {
            get
            {
                return this[i];
            }
            set
            {
                this[i] = value;
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
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad g = new Universidad();
            xml.Leer(".",out g);
            return g;
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool ret = false;
            xml.Guardar(".", uni.ToString());
            ret = true;
            return ret;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MostrarDatos(this));            
            return sb.ToString();
        }
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornadas = new List<Jornada>();
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADAS: ");            
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.Append(jornada.ToString());
            }
            sb.AppendLine("PROFESORES: ");
            foreach (Profesor profesor in uni.Instructores)
            {
                sb.Append(profesor.ToString());
            }
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in uni.Alumnos)
            {
                sb.Append(alumno.ToString());
            }
            return sb.ToString();
        }

    }
}
