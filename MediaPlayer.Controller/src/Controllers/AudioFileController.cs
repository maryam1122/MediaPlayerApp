using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Controller.src.Controllers
{
    public class AudioFileController : MediaFileController<AudioFile, AudioFileReadDTO>
    {
        public AudioFileController(IAudioFileService service) : base(service)
        {
        }
    }
}