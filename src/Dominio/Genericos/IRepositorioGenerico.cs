
namespace Dominio.Genericos
{
    public interface IRepositorioGenerico<TID, T>
        where TID : IIdGenerico
        where T : EntidadGenerica<TID>
    {
        Task<List<T>> ListarTodos();
        Task<T?> ListarPorId(TID id);
        void Crear(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T id);
    }
}
