using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(this.ToString());
            return sb.ToString();
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases clases in i.clasesDelDia)
            {
                if (clases == clase)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }        
        static Profesor()
        {
            random = new Random(1654661);
            
        }
        private Profesor()
        {
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "";
        }
    }
}
