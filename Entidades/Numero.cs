using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0.0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }


        private double ValidarNumero(string strNumero)
        {
            double response;

            double.TryParse(strNumero, out response);

            return response;
        }

        private bool EsBinario(string binario)
        {
            bool response = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    response = false;
                    break;
                }
            }

            return response;
        }

        public string BinarioDecimal(string binario)
        {
            string response = "";
            int posicion = 0;

            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    short digitoActual = short.Parse(binario[i].ToString());

                    double operacion = Math.Pow(2, posicion);
                    response += (digitoActual * operacion).ToString();

                    posicion++;
                }
            }
            else
            {
                response = "Valor inválido";
            }

            return response;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            double response = double.MinValue;

            if (!(num1.numero != response || num2.numero != response))
            {
                response = num1.numero / num2.numero;
            }

            return response;
        }
    }
}
