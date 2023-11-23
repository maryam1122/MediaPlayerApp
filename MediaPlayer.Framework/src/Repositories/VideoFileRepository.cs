using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Shared;

namespace MediaPlayer.Framework.src.Repositories
{
    public class VideoFileRepository : MediaFileRepository<VideoFile>, IVideoFileRepo
    {
        public VideoFileRepository(Database database) : base(database)
        {
        }
    }
}