namespace MusicCollection.DAL.Interfaces
{
	public interface IMusicRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAllMusicAsync(string MusicName);
		Task CreateMusicAsync(TEntity music);
	}
}
