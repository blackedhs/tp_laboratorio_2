using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public sealed class Profesor : Universitario
  {
    private Queue<Universidad.EClases> clasesDelDia;
    private Random random;
    private void _randomClases()
    {

    }
    protected string MostrarDatos()
    {
      StringBuilder sb = new StringBuilder();
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
    protected string ParticiparEnClase()
    {
      StringBuilder sb = new StringBuilder();
      return sb.ToString();
    }
    static Profesor()
    {
    }
    private Profesor()
    {
    }
    public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
    {

    }
    public override string ToString()
    {
      return base.ToString();
    }
  }
}
