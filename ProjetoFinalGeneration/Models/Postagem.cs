using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalGeneration.Models
{
    [Table("tb_postagens")]
    public class Postagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Titulo { get; set; }
        [Required]
        [MinLength(10)]
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        [ForeignKey("Tema")]
        public int Temaid { get; set; }
    }
}
