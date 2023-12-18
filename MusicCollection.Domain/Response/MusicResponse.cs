using MusicCollection.Domain.Enum;
using MusicCollection.Domain.Interfaces;
using MusicCollection.DAL.DTO;

namespace MusicCollection.Domain.Response
{
    public class MusicResponse : IBaseResponse<IEnumerable<MusicDTO>>
    {
        public IEnumerable<MusicDTO> Data { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
