using Microsoft.EntityFrameworkCore;
using NetKubernetes.Models;

namespace NetKubernetes.Data.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _contexto;
  

    public CategoryRepository(
        AppDbContext contexto
    )
    {
        _contexto = contexto;
     
    }
    
    

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
       return await _contexto.Categories!.ToListAsync();
    }

   
}