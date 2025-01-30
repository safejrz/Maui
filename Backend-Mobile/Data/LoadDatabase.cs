using Microsoft.AspNetCore.Identity;
using NetKubernetes.Models;
using Newtonsoft.Json;

namespace NetKubernetes.Data;

public class LoadDatabase {

    public static async Task InsertarData(AppDbContext context, UserManager<Usuario> usuarioManager)
    {
        if(!usuarioManager.Users.Any())
        {
            var usuario = new Usuario {
                Id = "9767447b-0ab7-41b7-bef7-9958dd66e44e",
                Nombre = "Vaxi",
                Apellido = "Drez",
                Email = "vaxi.drez.social@gmail.com",
                UserName = "vaxi.drez",
                Telefono = "98142545"
            };

            await usuarioManager.CreateAsync(usuario, "PasswordVxidrez123$"); 
        }
        if(!context.Categories!.Any())
        {
            var categoryData = File.ReadAllText("../BACKEND-MOBILE/Resources/json/category.json");
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
            await context.Categories!.AddRangeAsync(categories!);
            await context.SaveChangesAsync();
        }

        if(!context.Inmuebles!.Any())
        {
            
            var inmuebleData = File.ReadAllText("../BACKEND-MOBILE/Resources/json/inmueble.json");
            var inmuebles = JsonConvert.DeserializeObject<List<Inmueble>>(inmuebleData);
            await context.Inmuebles!.AddRangeAsync(inmuebles!);
            await context.SaveChangesAsync();
        }
 
        context.SaveChanges();
    }

}