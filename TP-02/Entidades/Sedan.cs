using System;
using System.Text;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region "Enumerados"
        public enum ETipo { 
            CuatroPuertas,
            CincoPuertas 
        }
        #endregion

        #region "Atributos"
        private ETipo tipo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas; //Incongruencia con el PDF del TP2 (diagrama de clase de Sedan)
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio
        {
            get => ETamanio.Mediano;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Override de la clase Vehiculo, se mostrará la info del Vehiculo más la que contiene un Sedan
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TAMAÑO: {Tamanio}\r");
            sb.AppendLine($"TIPO: {tipo}\r");
            sb.AppendLine("---------------------");

            return "SEDAN\n" + base.Mostrar() + sb.ToString();
        }
        #endregion

    }
}
