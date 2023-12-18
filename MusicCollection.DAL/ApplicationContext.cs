using Microsoft.EntityFrameworkCore;
using MusicCollection.DAL.ModelContext;
using MusicCollection.Domain.Entity;

namespace MusicCollection.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Music> Musics => Set<Music>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicModelContext());
        }
    }
}
