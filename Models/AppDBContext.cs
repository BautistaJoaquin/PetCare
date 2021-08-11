using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace proyecto_mascotas.Models
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options): base(options)
        {
            _options = options; 

        }
        public virtual DbSet<ForumViewModel> foro {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //  modelBuilder.Entity<ForumViewModel>(entity =>
            // {
            //     entity.ToTable("posteos");
            //     entity.HasKey(e => e.idposteo);
            //     entity.Property(e => e.idposteo).HasColumnName("idposteo");

            //     entity.Property(e => e.Titulo)
            //         .IsRequired()
            //         .HasColumnName("titulo")
            //         .HasMaxLength(50)
            //         .IsUnicode(false);

            //     entity.Property(e => e.Desc)
            //         .HasColumnName("descripcion")
            //         .HasMaxLength(255)
            //         .IsUnicode(false);

            //     entity.Property(e => e.ImagePost)
            //         .HasColumnName("imagen");
                    
            // });
        } 
    }
}