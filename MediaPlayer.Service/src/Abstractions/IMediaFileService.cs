using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Service.src.Abstractions
{
    public interface IMediaFileService<T, TReadDTO>
    where T : MediaFile
    where TReadDTO : MediaFileReadDTO
    {
        List<TReadDTO> GetAllFiles(int limit, int offset);
        List<TReadDTO> FindByTitle(string title);
    }
}