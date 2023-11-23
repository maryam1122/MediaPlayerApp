using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Shared;

namespace MediaPlayer.Framework.src.Repositories
{
    public class AudioFileRepository : MediaFileRepository<AudioFile>, IAudioFileRepo
    {
        public AudioFileRepository(Database database) : base(database)
        {
        }
    }
}