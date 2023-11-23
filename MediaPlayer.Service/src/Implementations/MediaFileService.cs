using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;
using MediaPlayer.Service.src.Shared;

namespace MediaPlayer.Service.src
{
    public abstract class MediaFileService<T, TReadDTO> : IMediaFileService<T, TReadDTO>
    where T : MediaFile, new()
    where TReadDTO : MediaFileReadDTO, new()
    {
        private IMediaFileRepo<T> _repo;

        public MediaFileService(IMediaFileRepo<T> repo)
        {
            _repo = repo;
        }

        public List<TReadDTO>? GetAllFiles(int limit, int offset)
        {
            // _mediaFiles.Sort((a, b) => a.Duration > b.Duration ? 1 : -1);
            // return _mediaFiles.Skip(offset).Take(limit).ToList();
            if (limit < 0 || offset < 0)
            {
                throw new InvalidDataException();
            }
            return _repo.GetAllFiles(limit, offset)?.Select(file => Mapper.Convert<T, TReadDTO>(file)).ToList();
        }

        public List<TReadDTO> FindByTitle(string title)
        {
            var files =  _repo.FindByTitle(title);
            return files.Select(file => Mapper.Convert<T, TReadDTO>(file)).ToList();
        }
    }
}