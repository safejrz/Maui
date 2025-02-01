using Microsoft.EntityFrameworkCore;
using NetKubernetes.Models;

namespace NetKubernetes.Data.Compras;

public class CompraRepository : ICompraRepository{
    private readonly AppDbContext _contexto;

    public CompraRepository(AppDbContext context)
    {
        _contexto = context;
    }
    
    public async Task SaveCompras(IEnumerable<Compra> compras)
    {
        await _contexto.Compras!.AddRangeAsync(compras);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<Compra>> GetAll()
    {
        return await _contexto.Compras!.ToListAsync();
    }
}