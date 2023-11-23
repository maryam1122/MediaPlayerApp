using MediaPlayer.Core.src.Entities;
using MediaPlayer.Core.src.Shared;

namespace MediaPlayer.Framework.src
{
    public class Database
    {
        public List<AudioFile> AudioFiles { get; set; }
        public List<VideoFile> VideoFiles { get; set; }
        public List<User> Users { get; set; }
        public List<PlayTrack> PlayTracks { get; set; }

        private Dictionary<Type, object> _collections;

        public Database()
        {
            VideoFiles = new List<VideoFile>{
                new VideoFile { Id = 1, Duration = 3.5, Title = "Morning Melody" },
                new VideoFile { Id = 2, Duration = 4.0, Title = "Evening Serenade" },
                new VideoFile { Id = 3, Duration = 2.8, Title = "Rainy Day Jazz" },
                new VideoFile { Id = 4, Duration = 3.1, Title = "Sunset Acoustics" },
                new VideoFile { Id = 5, Duration = 4.5, Title = "Night Sky Symphony" },
                new VideoFile { Id = 6, Duration = 2.2, Title = "Urban Beat" },
                new VideoFile { Id = 7, Duration = 3.6, Title = "Countryside Bliss" },
                new VideoFile { Id = 8, Duration = 4.2, Title = "City Lights Groove" },
                new VideoFile { Id = 9, Duration = 3.3, Title = "Mountain Echo" },
                new VideoFile { Id = 10, Duration = 2.7, Title = "Ocean Waves" }

            };
            AudioFiles = new List<AudioFile>{
                new AudioFile { Id = 11, Duration = 3.8, Title = "Wind Chime Harmony" },
                new AudioFile { Id = 12, Duration = 3.9, Title = "Forest Whispers" },
                new AudioFile { Id = 13, Duration = 4.1, Title = "Starlight Tune" },
                new AudioFile { Id = 14, Duration = 2.5, Title = "Desert Rhythm" },
                new AudioFile { Id = 15, Duration = 3.2, Title = "Rainforest Chorus" },
                new AudioFile { Id = 16, Duration = 2.9, Title = "Safari Groove" },
                new AudioFile { Id = 17, Duration = 3.7, Title = "Riverbank Melody" },
                new AudioFile { Id = 18, Duration = 2.3, Title = "Glacier Echoes" },
                new AudioFile { Id = 19, Duration = 4.3, Title = "Volcano Pulse" },
                new AudioFile { Id = 20, Duration = 3.4, Title = "Tundra Harmony" }
            };
            Users = new List<User>{
                new Subscriber { Id = 1, Age = 18, Name = "Suri" },
                new Subscriber { Id = 2, Age = 22, Name = "Alex" },
                new Subscriber { Id = 3, Age = 30, Name = "Morgan" },
                new Subscriber { Id = 4, Age = 25, Name = "Jamie" },
                new Subscriber { Id = 5, Age = 27, Name = "Taylor" },
                new Subscriber { Id = 6, Age = 35, Name = "Jordan" }
            };
            PlayTracks = new List<PlayTrack>
            {
                new PlayTrack(1),
                new PlayTrack(2),
                new PlayTrack(3),
            };
            _collections = new Dictionary<Type, object>
            {
                { typeof(VideoFile), VideoFiles },
                { typeof(AudioFile), AudioFiles },
                { typeof(User), Users },
                { typeof(PlayTrack), PlayTracks}
            };
        }
        public List<T>? GetData<T>()
        {
            Type type = typeof(T);

            if (_collections.TryGetValue(type, out object? collection))
            {
                return collection as List<T>;
            }

            throw new InvalidOperationException($"No collection found for type {type}");

        }
    }
}