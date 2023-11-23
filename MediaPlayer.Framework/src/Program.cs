using MediaPlayer.Controller.src;
using MediaPlayer.Controller.src.Controllers;
using MediaPlayer.Core.src.Entities;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Framework.src;
using MediaPlayer.Framework.src.Repositories;
using MediaPlayer.Service.src;
using MediaPlayer.Service.src.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {
        var database = new Database();
        var audioRepo = new AudioFileRepository(database);
        var audioService = new AudioFileService(audioRepo);
        var audioConntroller = new AudioFileController(audioService);
        var files = audioConntroller.GetAllFiles();
        foreach (var file in files)
        {
            Console.WriteLine($"file {file.Title}");
        }

        //Test code for play track
        var track = new PlayTrack(1);
        var player = new AudioFile(){Duration = 2, Title="Morning tune"};
        track.Play(player);
        Console.WriteLine("Start blocking the thread");
        Console.WriteLine($"Current playing position: {track.CurrentPosition}");
        Thread.Sleep(500);
        Console.WriteLine("Finish blocking the thread");
    }
}

