using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCollection.Domain.Entity;

namespace MusicCollection.DAL.ModelContext
{
    public class MusicModelContext : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.Property(music => music.Id).ValueGeneratedOnAdd();
            builder.Property(music => music.UserName).IsRequired().HasMaxLength(20);
            builder.Property(music => music.MusicName).IsRequired().HasMaxLength(100);
            builder.Property(music => music.AuthorName).IsRequired().HasMaxLength(40);
        }
    }
}
