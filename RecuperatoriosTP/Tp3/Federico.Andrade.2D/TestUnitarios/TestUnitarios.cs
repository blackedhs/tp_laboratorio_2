using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using ClasesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Valida q se lance una excepcion cuando se quiere cargar un alumno existente
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestExceptionAlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno alum = new Alumno(1247, "federico", "andrade", "34152942", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            uni = uni + alum;
            uni = uni + alum;
        }
        /// <summary>
        /// Valida q se lance una excepcion cuando no hay un profesor q pueda dar una clase
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestExceptionSinProfesor()
        {
            Universidad uni = new Universidad();
            Profesor prof;
            prof = (uni == Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Valida q el alumno tome una clase dada
        /// </summary>
        [TestMethod]
        public void TestValidaAlumnoEnClase()
        {
            Alumno alum = new Alumno(1247, "federico", "andrade", "34152942", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsTrue(alum == Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Valida que se instancie la lista de alumnos cuando se instancia una universidad
        /// </summary>
        [TestMethod]
        public void TestListaAlumnosInstanciada()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
