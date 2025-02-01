using NetKubernetes.Dtos.BookmarkDtos;
using NetKubernetes.Models;

namespace NetKubernetes.Data.Bookmarks;

public interface IBookmarkRepository {

    Task<BookmarkResponseDto> Create(BookmarkRequestDto request);

    Task Delete(int inmuebleId);

    Task<IEnumerable<Bookmark>> GetByUsuarioId();

}