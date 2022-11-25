using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels;

public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "O Nome é obrigatorio")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Mínimo de caracteres excedido")]
    public string Name { get; set; }   
    
    [Required(ErrorMessage = "O Slug é obrigatório")]
    public string Slug { get; set; }

}