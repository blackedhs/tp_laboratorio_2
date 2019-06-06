using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
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
    }
    public Jornada(Universidad.EClases clase, Profesor instructor)
    {
    }
    public string Leer()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString();
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
    public static Jornada operator +(Jornada j,Alumno a)
    {
      if (j != a)
        j.alumnos.Add(a);
      return j;
    }
    public override string ToString()
    {
      return base.ToString();
    }
  }
}
