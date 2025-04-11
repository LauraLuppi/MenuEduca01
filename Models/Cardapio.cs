using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MenuEduca01.Models
{
    public class Cardapio
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Nome da Refeição")]
        public string NomeRefeicao { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Ingredientes")]
        public string Ingredientes { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Calorias")]
        public int Calorias { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [Display(Name = "Data")]
        public DateOnly Data { get; set; }


        [Required(ErrorMessage = "Preencher isso é obrigatório")]
        [ForeignKey("UsuariosId")]
        [Display(Name = "Usuário")]
        public int UsuariosId { get; set; }
    }
}
