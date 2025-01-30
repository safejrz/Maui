using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetKubernetes.Models;

public class Category {

    [Key]
    [Required]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Inmueble>? Inmuebles { get; set; }
    
}