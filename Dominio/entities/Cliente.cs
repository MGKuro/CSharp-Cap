using Dominio.Infraestructura;

namespace Dominio.entities
{
    public class Cliente : EntidadBase
    {
        public virtual string Nombre { get; set; }
        public virtual string Reino { get; set; }
    }
}
