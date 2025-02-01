using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetKubernetes.Models;

public class Inmueble {
    [Key]
    [Required]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Detalle { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Precio { get; set; }

    public string? ImagenUrl { get; set; }
    public string? Imagen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public Guid? UsuarioId { get; set; }

    public int CategoryId {get;set;}
    public virtual Category? Category {get;set;}

    public bool IsTrending {get;set;}

    public bool IsBookmarkEnabled {get;set;}
 
    public virtual ICollection<Usuario>? Usuarios { get; set; }
    public virtual ICollection<Bookmark>? Bookmarks { get; set; } 
}