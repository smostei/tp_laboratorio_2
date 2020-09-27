using System;
using System.Text;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region "Constructores"
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color) {}
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override ETamanio Tamanio
        {
            get => ETamanio.Chico;      
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Override de la clase Vehiculo, se mostrará la info del Vehiculo más la que contiene un Ciclomotor
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TAMAÑO: {Tamanio}\r");
            sb.AppendLine("---------------------");
            
            return "CICLOMOTOR\n" + base.Mostrar() + sb.ToString();
        }
        #endregion

    }
}
