using MusicCollection.DAL.DTO;
using MusicCollection.DAL.Interfaces;
using MusicCollection.Domain.Entity;
using MusicCollection.Domain.Enum;

using MusicCollection.Service.Interfaces;


namespace MusicCollection.Service.Implimentations
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository<Music> MusicRepository;

        public MusicService(IMusicRepository<Music> MusicRepository)
        {
            this.MusicRepository = MusicRepository;
        }

        public async Task<StatusCode> CreateMusicAsync(Music musicDTO)
        {
            Music music = new Music() { AuthorName = musicDTO.AuthorName, MusicName = musicDTO.MusicName, UserName = musicDTO.UserName };
            await MusicRepository.CreateMusicAsync(music);
            return StatusCode.OK;
        }

        public async Task<IEnumerable<Music>> GetAllMusicAsync(string MusicName)
        {
            return await MusicRepository.GetAllMusicAsync(MusicName);
        }
    }
}
