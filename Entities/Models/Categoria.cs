using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Categoria
{
  [Column("CategoriaId")]
  public int Id { get; set; }
  
  [Required(ErrorMessage = "{0} es requerido.")]
  [MaxLength(60, ErrorMessage = "La longitud máxima del campo {0} es de {1} caracteres.")]
  public string? Codigo { get; set; }
  
  [Required(ErrorMessage = "{0} es requerido.")]
  [MaxLength(255, ErrorMessage = "La longitud máxima del campo {0} es de {1} caracteres."), MinLength(5)]
  public string? Descripcion { get; set; }
  
  [Required(ErrorMessage = "{0} es requerido.")]
  public bool Activo { get; set; }
}