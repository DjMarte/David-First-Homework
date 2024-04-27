using System.ComponentModel.DataAnnotations;

namespace Primera_Tarea.Models;

public class Productos
{
	[Key]
	public int ProductoId { get; set; }

	[Required(ErrorMessage = "Descripción obligatoria")]

	public string? Descripcion { get; set; }

    [Range(0.1, 10000, ErrorMessage = "Ingrese un precio válido")]
    [Required(ErrorMessage = "Precio obligatorio")]
    public decimal Precio { get; set; }

	[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
	[Required(ErrorMessage ="Categoria Obligatoria")]

	public string? Categoria { get; set; }
}
