using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace proyecto_mascotas.Models
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions options): base(options)
        {
            

        }
        public DbSet<Forum> Forum {get;set;}

        public DbSet<ForumUser> ForumUser {get;set;}

        public DbSet<User> User {get;set;}
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<ForumUser>()
        .HasKey(fu => new { fu.ForumId , fu.UserId});

        modelBuilder.Entity<ForumUser>()
        .HasOne(fu => fu.Forum)
        .WithMany(p => p.ForumUser)
        .HasForeignKey(p => p.ForumId);  
        
        modelBuilder.Entity<ForumUser>()
        .HasOne(fu => fu.User)
        .WithMany(p => p.ForumUser)
        .HasForeignKey(p => p.UserId);
                       
        } 
    }
}