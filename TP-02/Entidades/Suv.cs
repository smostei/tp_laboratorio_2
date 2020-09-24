using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color) {}

        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get => ETamanio.Grande; 
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TAMAÑO: {Tamanio}\r");
            sb.AppendLine("---------------------");
            
            return "SUV\n" + base.Mostrar() + sb.ToString();
        }
    }
}
