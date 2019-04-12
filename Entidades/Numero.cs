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
        //
        public static string BinarioDecimal(string binario)
        {
            string numeroDecimal = "";
            double numeroRet = 0;
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
