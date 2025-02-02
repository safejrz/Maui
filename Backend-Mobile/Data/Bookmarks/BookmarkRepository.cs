using System.Resources;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetKubernetes.Middleware;
using NetKubernetes.Models;
using NetKubernetes.Token;
using NetKubernetes.Dtos.BookmarkDtos;
using AutoMapper;

namespace NetKubernetes.Data.Bookmarks;


public class BookmarkRepository : IBookmarkRepository
{
    private readonly AppDbContext _contexto;
    private readonly IUsuarioSesion _usuarioSesion;

    private readonly UserManager<Usuario> _userManager;

    private IMapper _mapper;

    public BookmarkRepository(
        AppDbContext contexto,
         IUsuarioSesion sesion,
          UserManager<Usuario> userManager,
            IMapper mapper
    )
    {
        _contexto = contexto;
        _usuarioSesion = sesion;
        _userManager = userManager;
        _mapper = mapper;

    }

    public async Task<BookmarkResponseDto> Create(BookmarkRequestDto request)
    {
        var bookmark = await _contexto.Bookmarks!
                           .FirstOrDefaultAsync(x => x.InmuebleId == request.InmuebleId && x.UsuarioId == request.UsuarioId);


        var inmueble = await _contexto.Inmuebles!
                        .FirstOrDefaultAsync(x => x.Id == request.InmuebleId);


        if (bookmark is not null)
        {
            _contexto.Bookmarks!.Remove(bookmark!);
            inmueble!.IsBookmarkEnabled = false;
        }
        else
        {
            bookmark = new Bookmark
            {
                InmuebleId = request.InmuebleId,
                UsuarioId = request.UsuarioId
            };

            _contexto.Bookmarks!.Add(bookmark);

            inmueble!.IsBookmarkEnabled = true;
        }

        await _contexto.SaveChangesAsync();

        return _mapper.Map<BookmarkResponseDto>(bookmark);
    }

    public async Task Delete(int inmuebleId)
    {
        var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
        if (usuario is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new { mensaje = "El usuario no es valido para hacer esta insercion" }
            );
        }

        var bookmark = await _contexto.Bookmarks!
                           .FirstOrDefaultAsync(x => x.InmuebleId == inmuebleId && x.UsuarioId == usuario.Id);

        _contexto.Bookmarks!.Remove(bookmark!);
        await _contexto.SaveChangesAsync();

    }

    public async Task<IEnumerable<Bookmark>> GetByUsuarioId()
    {
        var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
        if (usuario is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new { mensaje = "El usuario no es valido para hacer esta insercion" }
            );
        }

        var result = await (from a in _contexto.Bookmarks
                            join b in _contexto.Inmuebles! on a.InmuebleId equals b.Id
                            where a.UsuarioId == usuario.Id
                            select new Bookmark
                            {
                                Inmueble = b,
                                UsuarioId = a.UsuarioId,
                                InmuebleId = a.InmuebleId
                            }).Distinct().ToListAsync();

        return result;
    }




}