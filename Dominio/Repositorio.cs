using Dominio;
using Dominio.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dominio
{
    public class Repositorio<T> : IRepositorio<T> where T :EntidadBase
    {
        private readonly Contexto contexto;

        public Repositorio(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public async Task Actualizar(T entidad)
        {
            contexto.Entry(entidad).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public async Task<List<T>> Buscar(Expression<Func<T, bool>> predicado)
        {
            return await contexto.Set<T>().Where(predicado).Where(e => e.FechaElimina == null).ToListAsync();
        }

        public async Task Eliminar(T entidad)
        {
            entidad.FechaElimina = DateTime.Now;
            entidad.UsuarioElimina = 0;
            contexto.Entry(entidad).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public async Task Crear(T entidad)
        {
            contexto.Entry(entidad).State = EntityState.Added;
            await contexto.Set<T>().AddAsync(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task<T> Obtener(int Id)
        {
            try
            {
                return await contexto.Set<T>().FindAsync(Id);
            }
            catch (Exception nullear) {
                nullear.ToString();
                return null;
            }
        }
    }
}
