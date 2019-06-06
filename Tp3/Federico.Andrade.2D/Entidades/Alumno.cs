using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public sealed class Alumno:Universitario
  {
    public enum EEstadoCuenta
    {
      AlDia,
      Deudor,
      Becado
    }
    private Universidad.EClases claseQueToma;
    private EEstadoCuenta estadoCuenta;
    public Alumno()
    {

    }
    public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
    {
    }
    public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma,EEstadoCuenta estadoCuenta)
    {
    }
    protected override string MostrarDatos()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString();
    }
    public static bool operator ==(Alumno a, Universidad.EClases clase)
    {
      return a.claseQueToma = clase;
    }
    public static bool operator !=(Alumno a, Universidad.EClases clase)
    {
      return !(a == clase);
    }
    protected override string ParticiparEnClase()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString();
    }
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString();
    }
  }
}
