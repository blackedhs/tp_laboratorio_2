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
		/// <summary>
        /// otorga dos clases aleatoriamente
		/// <summary>
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
		/// <summary>
        /// espone los datos del profesor
		/// <summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
		/// <summary>
        /// un profesor es igual a una universidad cuando se encuentra en la lista de profesores
		/// <summary>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases clases in i.clasesDelDia)
            {
                if (clases == clase)
                    return true;
            }
            return false;
        }
		/// <summary>
        /// un profesor es distinto a una universidad cuando no se encuentra en la lista de profesores
		/// <summary>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
		/// <summary>
        /// constructor estatico
		/// <summary>
        static Profesor()
        {
            random = new Random();            
        }
		/// <summary>
        /// constructor sin params
		/// <summary>
        private Profesor()
        {
        }
		/// <summary>
        /// constructor de instancia
		/// <summary>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();            
        }
		/// <summary>
        /// espone los datos del profesor
		/// <summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.MostrarDatos());            
            return sb.ToString();
        }
		/// <summary>
        /// muestra las clases a las q pertenece el profesor
		/// <summary>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }
    }
}
