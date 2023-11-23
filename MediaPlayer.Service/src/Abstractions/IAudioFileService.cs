using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Service.src.Abstractions
{
    public interface IAudioFileService : IMediaFileService<AudioFile, AudioFileReadDTO>
    {
        
    }
}