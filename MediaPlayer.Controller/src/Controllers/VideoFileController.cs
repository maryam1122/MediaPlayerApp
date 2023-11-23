using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Controller.src.Controllers
{
    public class VideoFileController : MediaFileController<VideoFile, VideoFileReadDTO>
    {
        public VideoFileController(IVideoFileService service) : base(service)
        {
        }
    }
}