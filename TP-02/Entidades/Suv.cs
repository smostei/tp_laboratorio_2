using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region "Constructores"
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color) {}
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get => ETamanio.Grande; 
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Override de la clase Vehiculo, se mostrará la info del Vehiculo más la que contiene una SUV
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TAMAÑO: {Tamanio}\r");
            sb.AppendLine("---------------------");
            
            return "SUV\n" + base.Mostrar() + sb.ToString();
        }
        #endregion
    }
}
