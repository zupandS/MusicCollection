using MusicCollection.DAL.Interfaces;
using MusicCollection.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MusicCollection.DAL.Repositories
{
    public class MusicRepository : IMusicRepository<Music>
    {
        private readonly ApplicationContext DbContext;

        public MusicRepository(ApplicationContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task CreateMusicAsync(Music music)
        {
           await DbContext.Musics.AddAsync(music);
           await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Music>> GetAllMusicAsync(string MusicName)
        {
           return await DbContext.Musics.Where(elements => elements.MusicName.ToLower().Contains(MusicName)).ToListAsync();
        }
    }
}
