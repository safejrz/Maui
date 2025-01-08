using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAccess;

internal class ShopDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopComputer");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Electronics"),
            new Category(2, "Computers"),
            new Category(3, "Mobile"),
            new Category(4, "Desktop"),
            new Category(5, "Audio"),
            new Category(6, "Home devices"),
            new Category(7, "Toys and games")
        );

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Radio digital", "Es una radio de banda ancha", 100, 1),
            new Product(2, "Reloj electronico honda", "Reloj de muy buena sincronizacion", 50, 1),
            new Product(3, "Computadora de escritorio", "Computadora de escritorio con 8GB de RAM", 1500, 2),
            new Product(4, "Computadora portatil", "Computadora portatil con 16GB de RAM", 8000, 2),
            new Product(5, "Celular Samsung", "Celular Samsung con 4GB de RAM", 300, 3),
            new Product(6, "Celular iPhone", "Celular iPhone con 8GB de RAM", 600, 3)
            );

        modelBuilder.Entity<Client>().HasData(
            new Client(1, "Juan Perez", "Calle 123"),
            new Client(2, "Maria Lopez", "Calle 456")
            );
    }
}

public record Category(int Id, string Name);
public record Product(int Id, string Name, string Description, decimal Price, int CategoryId)
{
    public Category Category { get; set; } = default!;
}

public record Client(int Id, string Name, string Address);