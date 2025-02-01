using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetKubernetes.Middleware;
using NetKubernetes.Models;
using NetKubernetes.Token;

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