using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoGrendene.Domain.Usuarios
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
