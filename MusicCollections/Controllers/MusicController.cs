using Microsoft.AspNetCore.Mvc;
using MusicCollection.DAL.DTO;
using MusicCollection.Domain.Entity;
using MusicCollection.Domain.Response;
using MusicCollection.Service.Interfaces;

namespace MusicCollection.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Musiccontroller : ControllerBase
	{
		private readonly IMusicService MusicService;

        public Musiccontroller(IMusicService MusicService)
        {
			this.MusicService = MusicService;
        }

		[HttpPost]
		public async Task<IActionResult> CreateMusic(MusicDTO musicDTO)
		{
			if (musicDTO != null)
			{
                Music music = new Music() { AuthorName = musicDTO.AuthorName, MusicName = musicDTO.MusicName, UserName = musicDTO.UserName };
                await MusicService.CreateMusicAsync(music);
                return Ok();
            }
			else 
			{ 
				return BadRequest();
			}
		}

		[HttpGet]
		public async Task<MusicResponse> GetAllMusic(string musicName)
		{
			IEnumerable<Music> musics = null;

            if (musicName != null)
			{
                musics = await MusicService.GetAllMusicAsync(musicName);
            }
		    if (musics != null)
			{
                IEnumerable<MusicDTO> musicsDTO = musics.Select(
                elements => new MusicDTO()
                { AuthorName = elements.AuthorName, MusicName = elements.MusicName, UserName = elements.UserName });

                return new MusicResponse() { Data = musicsDTO, StatusCode = Domain.Enum.StatusCode.OK };
            }
			else
			{
                return new MusicResponse() { Data = null, StatusCode = Domain.Enum.StatusCode.BadRequst };
            }
		}
	}
}
