using System;
using System.Linq;
using P01DemoEFCore.Models;

namespace P01DemoEFCore
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            // dotnet ef dbcontext scaffold "Server=.;Database=MusicX;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -d

            var db = new MusicXContext();
            Console.WriteLine(db.Songs.Count());
            Console.WriteLine(db.Artists.Count());

            var topArtistsBySongsCount = db.Artists
                .OrderByDescending(x => x.SongArtists.Count())
                .Select( x => new {x.Name, Count = x.SongArtists.Count()})
                .Take(10).ToList();

            foreach (var artist in topArtistsBySongsCount)
            {
                Console.WriteLine($"{artist.Name} {artist.Count}");
            }

        }
    }
}
