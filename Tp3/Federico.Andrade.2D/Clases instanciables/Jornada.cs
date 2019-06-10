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
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        public static string Leer()
        {
            Texto txt = new Texto();
            string dato;
            txt.Leer("./Jornada.txt", out dato);
            return dato;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase: "+this.clase);
            sb.AppendLine("Profesor: "+this.instructor);
            sb.AppendLine("Alumnos: ");
            foreach (Alumno alumno in this.alumnos)
            {
                sb.Append(alumno.ToString());
            }           
            return sb.ToString();
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            bool ret = false;           
            txt.Guardar("./Jornada.txt", jornada.ToString());
            ret = true;          
            return ret;
        }
    }
}
