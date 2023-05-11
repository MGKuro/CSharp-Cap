using Microsoft.EntityFrameworkCore;
using Dominio.entities;

namespace Dominio
{
    
    public class Contexto : DbContext
    {
        protected readonly IConfiguration Config;
        /*public Contexto(IConfiguration config){
            Config = config;
        }*/
        public Contexto(DbContextOptions<Contexto> options) : base(options){}

        public DbSet<Cliente> Clientes { get; set; }
    }
}
