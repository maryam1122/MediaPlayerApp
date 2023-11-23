using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Core.src.Shared
{
    public abstract class MediaFile
    {
        public double Duration { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
    }
}