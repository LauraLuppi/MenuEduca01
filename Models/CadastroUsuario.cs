using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MenuEduca01.Models
{
    public class CadastroUsuario
    {
        [Display(Name = "Código")]
        public Guid CadastroUsuarioId { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        public string NomeCompleto { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        public string CPF { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Tipo Usuário")]
        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        public string TipoUsuario { get; set; }
        public Guid? AppUserId { get; set; }
        public IdentityUser? IdentityUser { get; set; }
    }
}
