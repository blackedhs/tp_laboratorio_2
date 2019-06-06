using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
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

    public Jornada this[int i] { get; set; }

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


  }
}
