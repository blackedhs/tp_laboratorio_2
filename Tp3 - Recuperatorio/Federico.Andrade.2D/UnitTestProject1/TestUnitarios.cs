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
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestMethod1()
        {
            Universidad uni = new Universidad();
            Alumno alum = new Alumno(1247, "federico", "andrade", "34152942", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            uni = uni + alum ;
            uni = uni + alum ;
        }
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestMethod2()
        {
            Universidad uni = new Universidad();
            Profesor prof;
            prof= (uni == Universidad.EClases.Laboratorio);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Alumno alum = new Alumno(1247, "federico", "andrade", "34152942", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsTrue(alum.DNI < 100000000);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
