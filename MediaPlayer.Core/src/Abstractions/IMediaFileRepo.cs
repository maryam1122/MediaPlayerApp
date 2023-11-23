using MediaPlayer.Core.src.Shared;

namespace MediaPlayer.Core.src.Abstractions
{
    public interface IMediaFileRepo<T> where T : MediaFile
    {
        List<T>? GetAllFiles(int limit, int offset);
        List<T>? FindByTitle(string title);
    }
}