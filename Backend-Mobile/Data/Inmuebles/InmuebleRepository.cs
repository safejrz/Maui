using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetKubernetes.Middleware;
using NetKubernetes.Models;
using NetKubernetes.Token;

namespace NetKubernetes.Data.Inmuebles;

public class InmuebleRepository : IInmuebleRepository
{
    private readonly AppDbContext _contexto;
    private readonly IUsuarioSesion _usuarioSesion;

    private readonly UserManager<Usuario> _userManager;

    public InmuebleRepository(
        AppDbContext contexto,
        IUsuarioSesion sesion,
        UserManager<Usuario> userManager
    )
    {
        _contexto = contexto;
        _usuarioSesion = sesion;
        _userManager = userManager; 
    }

    public async Task CreateInmueble(Inmueble inmueble)
    {
        var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
        if (usuario is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new { mensaje = "El usuario no es valido para hacer esta insercion" }
            );
        }

        if (inmueble is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.BadRequest,
                new { mensaje = "Los datos del inmueble son incorrectos" }
            );
        }


        inmueble.FechaCreacion = DateTime.Now;
        inmueble.UsuarioId = Guid.Parse(usuario!.Id);

        await _contexto.Inmuebles!.AddAsync(inmueble);
    }

    public async Task DeleteInmueble(int id)
    {
        var inmueble = await _contexto.Inmuebles!
                            .FirstOrDefaultAsync(x => x.Id == id);

        _contexto.Inmuebles!.Remove(inmueble!);
    }

    public async Task<IEnumerable<Inmueble>> GetAllInmuebles()
    {
        return await _contexto.Inmuebles!.ToListAsync();
    }

    public async Task<IEnumerable<Inmueble>> SearchInmuebles(string search)
    {
        //return await _contexto.Inmuebles!.Where(s => s.Nombre!.Contains(search) || s.Detalle!.Contains(search)).ToListAsync();

        var inmuebles = from c in _contexto.Inmuebles!
                        where EF.Functions.Like(c.Detalle!, $"%{search}%") || EF.Functions.Like(c.Nombre!, $"%{search}%")
                        select c;

        return await inmuebles.ToListAsync();
    }


    public async Task<Inmueble> GetInmuebleById(int id)
    {
        return await _contexto.Inmuebles!.Include(a => a.Bookmarks!).FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public async Task<bool> SaveChanges()
    {
        return ((await _contexto.SaveChangesAsync()) >= 0);
    }

    public async Task<IEnumerable<Inmueble>> GetByCategoryId(int id)
    {
        var inmuebles = from c in _contexto.Inmuebles!
                        where c.CategoryId == id
                        select c;

        return await inmuebles.ToListAsync();
    }

    public async Task<IEnumerable<Inmueble>> GetTrending()
    {
        var inmuebles = from c in _contexto.Inmuebles!
                        where c.IsTrending == true
                        select c;

        return await inmuebles.ToListAsync();
    }

}