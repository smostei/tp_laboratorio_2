using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double operacion;

            switch(ValidarOperador(operador[0]))
            {
                case "-":
                    operacion = num1 - num2;
                    break;
                case "*":
                    operacion = num1 * num2;
                    break;
                case "/":
                    operacion = num1 / num2;
                    break;
                default:
                    operacion = num1 + num2;
                    break;
            }

            return operacion;
        }

        static string ValidarOperador(char operador)
        {
            string response;

            switch(operador)
            {
                case '-':
                    response = operador.ToString();
                    break;
                case '*':
                    response = operador.ToString();
                    break;
                case '/':
                    response = operador.ToString();
                    break;
                default:
                    response = "+";
                    break;
            }

            return response;
        }
    }
}
