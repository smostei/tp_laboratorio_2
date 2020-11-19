
namespace Archivos
{
    /// <summary>
    /// Interface que nos va a servir para leer o guardar archivos
    /// </summary>
    /// <typeparam name="T">objeto generico en el cuál guardaremos o leeremos la info en un archivo</typeparam>
    public interface IArchivo <T>
    {
        string RutaArchivo();
        bool Guardar(T datos);
        bool Leer(out T datos);
    }
}
