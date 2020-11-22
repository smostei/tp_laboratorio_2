using System;

namespace Extensiones
{
    public static class DateExtension
    {
        /// <summary>
        /// metodo de extensión en la clase DateTime para que nos devuelva la fecha actual formateada
        /// </summary>
        /// <param name="fecha">objeto datetime que devolverá la fecha actual</param>
        /// <returns>fecha formateada</returns>
        public static string FechaActualFormateada(this DateTime fecha)
        {
            return fecha.ToString("dd-MM-yyyy");
        }
    }
}
