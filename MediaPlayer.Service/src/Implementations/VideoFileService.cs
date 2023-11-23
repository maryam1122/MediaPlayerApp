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
    public class VideoFileService : MediaFileService<VideoFile, VideoFileReadDTO>, IVideoFileService
    {
        public VideoFileService(IVideoFileRepo repo) : base(repo)
        {
        }
    }
}