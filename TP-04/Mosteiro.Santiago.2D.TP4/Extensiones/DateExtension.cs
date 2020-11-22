using System;

namespace Extensiones
{
    public static class DateExtension
    {
        public static string FechaActualFormateada(this DateTime fecha)
        {
            return fecha.ToString("dd-MM-yyyy");
        }
    }
}
