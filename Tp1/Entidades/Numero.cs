using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// metodo para parsear de string a double           
        /// </summary>
        /// <param name="strNumero">string a parsear</param>
        /// <returns>string parseado o 0 si no se logro parsear</returns>
        double ValidarNumero(string strNumero)
        {
            double numero;

            return double.TryParse(strNumero, out numero) ? numero : 0;

        }
        /// <summary>
        /// set del atributo numero
        /// </summary>
        /// <param name="strNumero">string del numero a guardar</param>
        /// <returns>string del numero guardado</returns>
        string SetNumero(string strNumero)
        {
            numero = ValidarNumero(strNumero);
            return numero == 0 ? "0" : strNumero;
        }
        /// <summary>
        /// transforma de binario a decimal
        /// </summary>
        /// <param name="binario">string binario a transformar</param>
        /// <returns>retorna un string con el binario en formato decimal 
        /// o "Valor invalido" si el String pasado como param es invalido</returns>
        public static string BinarioDecimal(string binario)
        {
            string numeroDecimal = "";
            double numeroRet = 0;
            //Valido que el string binario contenga valores validos (solo 0 o 1)
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                    return "Valor invalido";
            }
            for (int i = 1; i <= binario.Length; i++)
            {
                numeroRet += double.Parse(binario[i - 1].ToString()) * (Math.Pow(2, binario.Length - i));
            }
            numeroDecimal += numeroRet;
            return numeroDecimal;
        }
        /// <summary>
        /// parsea de string a double para pasarlo como param al metodo DecimalBinario
        /// </summary>
        /// <param name="numero">string numero a transformar</param>
        /// <returns>retorna un string con el decimal en formato binario
        /// o "Valor invalido" si el String pasado como param es invalido</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] < '0' || numero[i] > '9')
                    return "Valor invalido";
            }
            return double.TryParse(numero, out numeroDecimal) ? DecimalBinario(numeroDecimal) : "Valor invalido";

        }
        /// <summary>
        /// tranforma de decimal a binario
        /// </summary>
        /// <param name="numero">numero a transformar</param>
        /// <returns>string con el numero decimal transformado a binario</returns>
        public static string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            while ((int)numero > 0)
            {
                numeroBinario = ((int)numero % 2).ToString() + numeroBinario;
                numero = numero / 2;
            }
            return numeroBinario;
        }
        /// <summary>
        /// constructor que setea el atributo numero en 0
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// constructor que setea el atributo numero en el valor contenido en numero
        /// </summary>
        /// <param name="numero">numero a setear</param>
        public Numero(double numero) : this(numero + "")
        {

        }
        /// <summary>
        /// constructor que setea el atributo numero en el valor contenido en numero
        /// </summary>
        /// <param name="numero">numero a setear</param>
        public Numero(string numero)
        {
            SetNumero(numero);
        }
        /// <summary>
        /// sobrecarga del operador -
        /// </summary>
        /// <param name="n1">valor del numero a restar</param>
        /// <param name="n2">valor del numero que resta</param>
        /// <returns>resultado de dicha operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// sobrecarga del operador +
        /// </summary>
        /// <param name="n1">objeto Numero 1</param>
        /// <param name="n2">objeto Numero 2</param>
        /// <returns>resultado de dicha operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// sobrecarga del operador /
        /// </summary>
        /// <param name="n1">objeto Numero 1 dividendo</param>
        /// <param name="n2">Objeto Numero 2 divisor</param>
        /// <returns>resultado de dicha operacion</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        /// <summary>
        /// sobrecarga del operador *
        /// </summary>
        /// <param name="n1">Objeto numero 1</param>
        /// <param name="n2">objeto Numero 2</param>
        /// <returns>resultado de dicha operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

    }
}
