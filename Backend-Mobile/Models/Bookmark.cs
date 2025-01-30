using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetKubernetes.Models;

public class Bookmark {
    public Usuario? Usuario { get; set; }
    public string? UsuarioId { get; set; }

    public Inmueble? Inmueble { get; set; }
    public int InmuebleId { get; set; }
}