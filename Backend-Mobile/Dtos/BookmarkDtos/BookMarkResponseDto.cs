namespace NetKubernetes.Dtos.BookmarkDtos;

public class BookmarkResponseDto
{
 
    public string? Nombre { get; set; }

    public decimal Precio { get; set; }

    public string?  ImagenUrl{ get; set; }
    public string?  Imagen{ get; set; }

    public string?  Address{ get; set; }
    public bool  Status{ get; set; }

    public string?  UsuarioId{ get; set; }

    public int InmuebleId {get;set;}

    public ICollection<BookmarkResponseDto>? Bookmarks { get; set; }

}