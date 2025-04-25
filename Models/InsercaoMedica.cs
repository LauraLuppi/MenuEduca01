using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuEduca01.Models
{

    public class InsercaoMedica
    {
        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        [Display(Name = "Código")]
        public Guid Id { get; set; }

        [ForeignKey("UsuariosId")]
        [Display(Name = "UsuariosId")]
        public string UsuariosId { get; set; }
        public CadastroUsuario? CadastroUsuario { get; set; }

        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        [Display(Name = "receitaMedica")]
        public string receitaMedica { get; set; }

        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        [Display(Name = "DataCadastro")]
        public string DataCadastro { get; set; }

        [Required(ErrorMessage = "Preencher esse campo é obrigatório")]
        [Display(Name = "Notificacao")]
        public string Notificacao { get; set; }

    }
}