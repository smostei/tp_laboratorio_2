
namespace Archivos
{
    /// <summary>
    /// Interface que nos va a servir para leer o guardar archivos
    /// </summary>
    /// <typeparam name="T">objeto generico en el cuál guardaremos o leeremos la info en un archivo</typeparam>
    interface IArchivo <T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
