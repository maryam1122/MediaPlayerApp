using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Service.src.Implementations
{
    public class AudioFileService : MediaFileService<AudioFile, AudioFileReadDTO>, IAudioFileService
    {
        public AudioFileService(IMediaFileRepo<AudioFile> repo) : base(repo)
        {
        }
    }
}