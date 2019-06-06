using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public abstract class Universitario:Persona
  {
    private int legajo;
    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }
    protected virtual string MostrarDatos()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString();
    }
    public static bool operator ==(Universitario pg1,Universitario pg2)
    {
      return true;
    }
    public static bool operator !=(Universitario pg1, Universitario pg2)
    {
      return !(pg1==pg2);
    }
    protected virtual string ParticiparEnClase()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString();
    }
    public Universitario()
    {
    }
    public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad): base(nombre,apellido,dni,nacionalidad)
    {
      this.legajo = legajo;
    }

  }
}
