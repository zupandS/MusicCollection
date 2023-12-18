using MusicCollection.DAL.DTO;
using MusicCollection.Domain.Entity;
using MusicCollection.Domain.Enum;

namespace MusicCollection.Service.Interfaces
{
	public interface IMusicService
	{
		Task<IEnumerable<Music>> GetAllMusicAsync(string MusicName);
		Task<StatusCode> CreateMusicAsync(Music music);
	}
}
