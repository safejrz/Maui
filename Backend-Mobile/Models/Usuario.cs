using Microsoft.AspNetCore.Identity;

namespace NetKubernetes.Models;

public class Usuario : IdentityUser {

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Inmueble>? Inmuebles { get; set; }
    public virtual ICollection<Bookmark>? Bookmarks { get; set; }
    
}