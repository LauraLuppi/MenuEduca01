using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MenuEduca01.Models
{
    public class Avaliacao
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [ForeignKey("UsuariosId")]
        [Display(Name = "UsuariosId")]
        public int UsuariosId { get; set; }

        public CadastroUsuario? CadastroUsuario { get; set; }

        [ForeignKey("CardapioId")]
        [Display(Name = "CardapioId")]
        public int CardapioId { get; set; }

        public Cardapio? Cardapio { get; set; }
    }
}
