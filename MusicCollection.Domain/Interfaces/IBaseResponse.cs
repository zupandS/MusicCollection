using MusicCollection.Domain.Enum;

namespace MusicCollection.Domain.Interfaces
{
	public interface IBaseResponse<TData> where TData : class
	{
        public TData Data { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
