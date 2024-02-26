using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalGeneration.Models
{
    [Table("tb_usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsEmailUnique", "User", ErrorMessage = "Email is already taken.")]
        public string Email { get; set; }
        public string Foto { get; set; }

        // Relacionamento com Postagem
        //public List<Postagem>? Postagens { get; set; }
    }
}
