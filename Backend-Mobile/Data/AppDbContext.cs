using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetKubernetes.Models;

namespace NetKubernetes.Data;

public class AppDbContext : IdentityDbContext<Usuario>{

 public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
 {
 }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>()
                .HasMany(c => c.Inmuebles)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

       builder.Entity<Inmueble>()
                .HasMany(a => a.Usuarios)
                .WithMany(v => v.Inmuebles)
                .UsingEntity<Bookmark>(
                     j => j
                       .HasOne(p => p.Usuario)
                       .WithMany(p => p.Bookmarks)
                       .HasForeignKey(p => p.UsuarioId),
                    j => j
                        .HasOne(p => p.Inmueble)
                        .WithMany(p => p.Bookmarks)
                        .HasForeignKey(p => p.InmuebleId),
                    j =>
                    {
                        j.HasKey(t => new { t.InmuebleId, t.UsuarioId });
                    }
                );

         //   modelBuilder.Entity<VideoActor>().Ignore(va => va.Id);


        builder.Entity<Usuario>().Property(x => x.Id).HasMaxLength(36);
        builder.Entity<Usuario>().Property(x => x.NormalizedUserName).HasMaxLength(90);
        builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(36);
        builder.Entity<IdentityRole>().Property(x => x.NormalizedName).HasMaxLength(90);
    }

    public DbSet<Inmueble>? Inmuebles {get;set;}
     public DbSet<Category>? Categories {get;set;}
      public DbSet<Bookmark>? Bookmarks {get;set;}

      public DbSet<Compra>? Compras {get;set;}

}