using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Shared;

namespace MediaPlayer.Framework.src.Repositories
{
    public class MediaFileRepository<T> : IMediaFileRepo<T> where T : MediaFile
    {
        private List<T>? _mediaFiles;
        // private Database _database = new Database();

        public MediaFileRepository(Database database) // dependency injection
        {
            _mediaFiles = database.GetData<T>();
        }
        public List<T>? FindByTitle(string title)
        {
            return _mediaFiles?.FindAll(m => m.Title.Contains(title));
        }

        public List<T> GetAllFiles(int limit, int offset)
        {
            _mediaFiles.Sort((a, b) => a.Duration > b.Duration ? 1 : -1);
            return _mediaFiles.Skip(offset).Take(limit).ToList();
        }
    }
}