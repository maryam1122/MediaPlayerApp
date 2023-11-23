using MediaPlayer.Controller.src.Shared;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Controller.src.Controllers
{
    public class MediaFileController<T, TReadDTO>
    where T : MediaFile
    where TReadDTO : MediaFileReadDTO
    {
        private IMediaFileService<T, TReadDTO> _mediaFileService;

        public MediaFileController(IMediaFileService<T, TReadDTO> service)
        {
            _mediaFileService = service;
        }

        public List<TReadDTO>? GetAllFiles(params object[] options)
        {
            try
            {
                var limit = 5;
                var offset = 0;
                if (options.Length >= 1) _ = int.TryParse(options[0].ToString(), out limit);
                if (options.Length >= 2) _ = int.TryParse(options[1].ToString(), out offset);
                Console.WriteLine($"Data returned from {this.GetType().Name}");
                return _mediaFileService.GetAllFiles(limit, offset);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error happen, cannot fetch data");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<TReadDTO> FindByTitle(object title)
        {
            if (title is null || title.ToString() is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var data = _mediaFileService.FindByTitle(title.ToString()!);
                if (data.Count == 0)
                {
                    throw CustomException.NotFoundException();
                }
                Console.WriteLine($"Data returned from {this.GetType().Name}");
                return data;
            }
        }
    }
}