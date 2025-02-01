using NetKubernetes.Dtos.BookmarkDtos;

namespace NetKubernetes.Dtos.InmuebleDtos;

public class InmuebleResponseDto
{

    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Detalle { get; set; }

    public decimal Precio { get; set; }

    public string? ImagenUrl { get; set; }
    public string? Imagen { get; set; }

    public string? Picture { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public Guid? UsuarioId { get; set; }

    public int CategoryId { get; set; }

    public bool IsTrending { get; set; }

    public bool IsBookmarkEnabled {get;set;}

    public string? BookmarkUserId {get;set;}

    public string Telefono {get;set;}  = "980-25541-2225";

    public ICollection<BookmarkResponseDto>? Bookmarks { get; set; }

}