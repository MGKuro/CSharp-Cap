using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Dominio.Infraestructura
{
    public interface IRepositorio<T> where T : EntidadBase
    {
        Task<List<T>> Buscar(Expression<Func<T, bool>> predicado);
        Task<T> Obtener(int Id);
        Task Crear(T entidad);
        Task Actualizar(T entidad);
        Task Eliminar(T entidad);
    }
}
