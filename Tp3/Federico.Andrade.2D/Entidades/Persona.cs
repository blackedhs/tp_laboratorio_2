using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public abstract class Persona
  {
    public enum ENacionalidad
    {
      Argentino,
      Extranjero
    }
    private string apellido;
    private int dni;
    private ENacionalidad nacionalidad;
    private string nombre;

    public string Nombre
    {
      get { return nombre; }
      set { nombre = value; }
    }

    public ENacionalidad Nacionalidad
    {
      get { return nacionalidad; }
      set { nacionalidad = value; }
    }
    public int DNI
    {
      get { return dni; }
      set { dni = value; }
    }
    public string Apellido
    {
      get { return apellido; }
      set { apellido = value; }
    }
    public string StringToDNI { set; }

    public Persona()
    {

    }
    public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
    {

    }
    public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
    {

    }
    public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
    {

    }
    public virtual string ToString()
    {
      StringBuilder sb = new StringBuilder();

      return sb.ToString(); 
    }
    private int ValidarDni(ENacionalidad nacionalidad,int dato)
    {
      return 1;
    }
    private int ValidarNombreApellido(string dato)
    {
      return 1;
    }
    private int ValidarDni(ENacionalidad nacionalidad, string dato)
    {
      return 1;
    }


  }
}
