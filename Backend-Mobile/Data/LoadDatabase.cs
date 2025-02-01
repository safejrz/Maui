using Microsoft.AspNetCore.Identity;
using NetKubernetes.Models;

namespace NetKubernetes.Data;

public class LoadDatabase
{

    public static async Task InsertarData(AppDbContext context, UserManager<Usuario> usuarioManager)
    {
        var userId = Guid.Empty;
        if (!usuarioManager.Users.Any())
        {
            var usuario = new Usuario
            {
                Nombre = "Vaxi",
                Apellido = "Drez",
                Email = "vaxi.drez.social@gmail.com",
                UserName = "vaxi.drez",
                Telefono = "98142545"
            };

            await usuarioManager.CreateAsync(usuario, "PasswordVxidrez123$");

            var user = await usuarioManager.FindByNameAsync("vaxi.drez");
            userId = new Guid(user!.Id);

        }
        if (!context.Categories!.Any())
        {
           
            var categories = new List<Category>
            {
                new Category{
                    Nombre = "Casas",
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fhouseicon.png?alt=media&token=985f244b-9401-4cf4-9070-d1d822693617"
                },
                new Category{
                    Nombre = "Departamentos",
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fapartmenticon.png?alt=media&token=c59ac50e-7980-4416-8407-b0678a26916c"
                },
                new Category{
                    Nombre = "Condominio",
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcondoicon.png?alt=media&token=dd98dbd3-45f4-467d-8367-dc3a80acfec8"
                },
                new Category{
                    Nombre = "Terreno",
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fterrenoicon.png?alt=media&token=23650056-2090-404b-ade9-3171f0ffe656"
                }
            };


            await context.Categories!.AddRangeAsync(categories!);
            await context.SaveChangesAsync();
        }

        if (!context.Inmuebles!.Any())
        {

            var inmuebles = new List<Inmueble>
            {
                new Inmueble{
                    Nombre = "Casa Familiar",
                    Detalle = "Patio delantero decorado tipo terraza, para recepcionar a los huespedes o como zona de área social. Cuenta con 4 dormitorios amplios (espacios para más de 1 cama) y baño independiente para cada dormitorio en buen estado.",
                    Direccion = "Av. Las Palmas 345",
                    Imagen = "casa_1.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcasa_1.jpg?alt=media&token=e038e761-60f9-4011-8b83-9743491b5db0",
                    Precio=452300,
                    IsTrending= true,
                    CategoryId = 1,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Inmueble de Verano",
                    Detalle = "Pasando el jardín, hay una construcción donde se encuentra el cuarto y baño de servicio en el primer piso, y en el segundo piso hay dos ambientes, uno de ellos es un estudio de música o aprovecharlo para lo que se necesite.",
                    Direccion = "Av. La Costanera 980",
                    Imagen = "casa_2.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcasa_2.jpg?alt=media&token=4bd5348b-7804-40db-b8cc-0a522465ea5e",
                    Precio=700000,
                    IsTrending= true,
                    CategoryId = 1,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Casa cerca a la playa",
                    Detalle = "La casa es de buen diseño e iluminación natural, escalera principal grande con jardín interior, hall de ingreso, sala de estar y comedor ideal para compartir en familia o amigos y con un amplio jardín posterior con zona de parrilla.",
                    Direccion = "Av. Los Jardines 312",
                    Imagen = "casa_3.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcasa_3.jpg?alt=media&token=969b99c3-d0ba-41df-838f-62576ddcba5a",
                    Precio=85000,
                    IsTrending= true,
                    CategoryId = 1,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Castillo en la ciudad",
                    Detalle = "La casa aparte de ser elegante, es super linda, iluminada y acogedora, tiene muy buenos acabados en toda la casa, techos con doble altura, todos los espacios están bien distribuidos y son amplios",
                    Direccion = "Pasaje Las Begonias 100",
                    Imagen = "casa_4.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcasa_4.jpg?alt=media&token=4592a620-9fb8-4b51-9828-6310ab4dafec",
                    Precio=120000,
                    IsTrending= true,
                    CategoryId = 1,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Casa frente al parque",
                    Detalle = "Amplio jardín en la parte frontal de la casa, pasos para llegar a la puerta de ingreso en mármol.",
                    Direccion = "Av. El Floral 781",
                    Imagen = "casa_5.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcasa_5.jpg?alt=media&token=371dd77f-6c9c-4ddb-9620-9be1b44ca490",
                    Precio=135000,
                    IsTrending= true,
                    CategoryId = 1,
                    UsuarioId = new Guid("9767447b-0ab7-41b7-bef7-9958dd66e44e")
                },
                new Inmueble{
                    Nombre = "Departamento de Lujo",
                    Detalle = "Departamento con 3 cuartos, y con marmol en cocina",
                    Direccion = "Av. Las Luces 90, # 120",
                    Imagen = "depa_1.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fdepa_1.jpg?alt=media&token=03ec4ac4-efea-4925-9b01-50d2e0eec062",
                    Precio=90000,
                    IsTrending= true,
                    CategoryId = 2,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Departamento centrico",
                    Detalle = "Departamento con 2 cuartos, y salida independiente",
                    Direccion = "Av. El Gran Chaparral 45, # 67",
                    Imagen = "depa_2.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fdepa_2.jpg?alt=media&token=85cec962-4abb-4aa6-8cc5-8c6a2a783fcd",
                    Precio=76000,
                    IsTrending= true,
                    CategoryId = 2,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Condominio con piscina",
                    Detalle = "Departamento con habitaciones de lujo",
                    Direccion =  "Av. El Gran Conjunto 167",
                    Imagen = "condo_1.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcondo_1.jpg?alt=media&token=04e01c89-2348-4401-9c92-ea9a03d6ec31",
                    Precio=132000,
                    IsTrending= true,
                    CategoryId = 3,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Condominio familiar",
                    Detalle = "Departamentos grandes para ninos y familias",
                    Direccion =  "Av. El Ballantyne 235",
                    Imagen = "condo_2.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fcondo_2.jpg?alt=media&token=3987b5b3-4119-42a2-8522-956c45103bcd",
                    Precio=150000,
                    IsTrending= true,
                    CategoryId = 3,
                    UsuarioId = userId
                },
                  new Inmueble{
                    Nombre = "Terreno grande cerca al rio",
                    Detalle = "Gran terreno listo para construir casas e inmuebles",
                    Direccion =   "Av. El Gran Salto 321",
                    Imagen = "terreno_1.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fterreno_1.jpg?alt=media&token=e8c6eda6-ab69-4dd4-b31b-964ac7da4389",
                    Precio=8000,
                    IsTrending= true,
                    CategoryId = 4,
                    UsuarioId = userId
                },
                new Inmueble{
                    Nombre = "Terreno cerca a la ciudad",
                    Detalle =  "Ubicado cerca a centros comerciales y centros nocturnos",
                    Direccion =    "Av. La Noche 200",
                    Imagen = "terreno_2.jpg",
                    ImagenUrl="https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/mobile%2Fterreno_2.jpg?alt=media&token=e68f3f17-8dbc-4ceb-b57a-6095dea09211",
                    Precio=7500,
                    IsTrending= true,
                    CategoryId = 4,
                    UsuarioId = userId
                },
            };

            await context.Inmuebles!.AddRangeAsync(inmuebles!);
            await context.SaveChangesAsync();
        }

        context.SaveChanges();
    }

    }