using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numero;

        double ValidarNumero(string strNumero)
        {
            double numero;

            return double.TryParse(strNumero, out numero) ? numero : 0;

        }
        string SetNumero(string strNumero)
        {
            numero = ValidarNumero(strNumero);
            return numero == 0 ? "0" : strNumero;
        }
        public string BinarioDecimal(string binario)
        {
            string numeroDecimal = "";
            double numeroRet = 0;
            for (int i = 0, j = binario.Length; i < binario.Length; i++, j--)
            {
                numeroRet = numeroRet + (binario[j] * (Math.Pow(2, i)));
            }
            numeroDecimal += numeroRet;
            return numeroDecimal;
        }
        public string DecimalBinario(string numero)
        {
            double numeroDecimal;
            return double.TryParse(numero, out numeroDecimal) ? DecimalBinario(numeroDecimal) : "Valor invalido";

        }
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            while (numero / 2 < 0)
            {
                numeroBinario = (numero % 2) + numeroBinario;
                numero = numero / 2;
            }
            return numeroBinario;
        }
        public Numero() : this(0)
        {

        }
        public Numero(double numero) : this(numero + "")
        {

        }
        public Numero(string numero)
        {
            SetNumero(numero);
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

    }
}
