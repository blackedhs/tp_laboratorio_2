using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// realiza la opericion deseada
        /// </summary>
        /// <param name="num1">objeto Numero 1</param>
        /// <param name="num2">objeto Numero 2</param>
        /// <param name="operador">operando deseado</param>
        /// <returns>resultado de la operacion, sil operador es invalido devuelve 0</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch (ValidarOperador(operador))
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "/":
                    return (num1 / num2).ToString() == (0.0/0).ToString() ? double.MinValue : num1 / num2;
                case "*":
                    return num1 * num2;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// valida el operador ingresado
        /// </summary>
        /// <param name="operador">valor del operador </param>
        /// <returns>devuelve el operador si es correcta la validacion o "+" de ser incorrecto</returns>
        private static string ValidarOperador(string operador)
        {
            return (operador == "+" || operador == "-" || operador == "*" || operador == "/" ) ? operador : "+";
        }
    }
}
