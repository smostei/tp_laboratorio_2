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

            if (EsBinario(binario))
            {
                if(String.IsNullOrEmpty(binario))
                {
                    response = "Valor inválido";
                } else
                {
                    response = Convert.ToInt32(binario, 2).ToString();
                }
                
            }
            else
            {
                response = "Valor inválido";
            }

            return response;
        }

        public string DecimalBinario(double numero)
        {
            string response = Convert.ToString((int)numero, 2);

            return response;
        }

        public string DecimalBinario(string numero)
        {
            int auxNum;

            int.TryParse(numero, out auxNum);
            
            string response = Convert.ToString(auxNum, 2);
            
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
            double response = 0.0;

            if (num1.numero != response && num2.numero != response)
            {
                response = num1.numero / num2.numero;
            }

            return response;
        }
    }
}
