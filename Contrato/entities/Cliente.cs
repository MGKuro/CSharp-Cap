using System.ComponentModel.DataAnnotations;

namespace Contrato.entities
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(4)]
        public string Reino { get; set; }


    }
}
