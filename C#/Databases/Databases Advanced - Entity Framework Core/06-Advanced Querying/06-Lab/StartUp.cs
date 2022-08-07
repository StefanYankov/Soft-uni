using System;
using System.Linq;
using Lab.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Lab
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new MusicXContext();

            /*
            // Raw SQL code execcution
            // db.Database.ExecuteSqlRaw("UPDATE Songs SET ModifiedOn = GETDATE()");
            var maxId = Console.ReadLine();

            //  var songs = db.Songs.FromSqlRaw("SELECT * FROM Songs WHERE Id <= {0}", maxId);
            var songs = db.Songs.FromSqlInterpolated($"SELECT * FROM Songs WHERE Id <= {maxId}");

            foreach (var song in songs)
            {
                Console.WriteLine(song.Id + " => " + song.Name);
            }

            //SoftUni DB
            var employeeId = 59;
            var projectId = 12;
            db.Database.ExecuteSqlInterpolated($"EXEC sp_AddToProject {employeeId}, {projectId}");

            // Object tracking and change tracker

            var songs2 = db.Songs.Where(x => x.Name.Contains("viv"));
            foreach (var song in songs)
            {
                    Console.WriteLine(song.Name);
                    song.ModifiedOn = DateTime.UtcNow;
            }

            db.SaveChanges();

           var songs3 = db.Songs
                .Where(x => x.Name.Contains("viv"))
                .Select(x => new Projection
                {
                    Name = x.Name,
                    ModifiedOn = x.ModifiedOn
                });

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);
                song.Name = "!!!!!!!!!!!!!!!!!";
            }

            db.SaveChanges();

            // bulk update and delete with z.entityframework.plus.EFCore

            db.Songs
                .Where(x => x.Id < 10)
                .Update(oldSong => new Songs {SourceItemId = oldSong.Id.ToString()});*/

            // Types of Loading - Lazy, Eager and Explicit Loading



            // Explicit Loading example
            var songs4 = db
                .Songs
                .Where(x => x.Id <= 10)
                .ToList();
            /*foreach (var song in songs4)     
            {
                Console.WriteLine(song.Name);

                db.Entry(song).Collection(x => x.SongArtists).Load();
                Console.WriteLine(song.SongArtists.Count());

                db.Entry(song).Reference(x => x.Source).Load();
                Console.WriteLine(song.Source.Name);
            }*/

            // Eager Loading example
            /*var songs5 = db
                .Songs
                .Include(x => x.Source)
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist) // include a navigational property to a navigational property
                .Where(x => x.Id <= 10)
                .ToList();
            foreach (var song in songs5)
            {
                Console.WriteLine(song.Name);
                Console.WriteLine(song.SongArtists.Count());
                Console.WriteLine(song.Source.Name);
            }*/

            // Lazy Loading example
            // classes and ICollections need to be virutal, so the lazy loading can inherit them and overwrite the methods where needed
            // nuget package Microsoft.EntityFrameworkCore.Proxies needed
            // OnConfiguring options add .UseLazyLoadingProxies()

            /*foreach (var song in songs4)
            {
                Console.WriteLine(song.Name);
                Console.WriteLine(song.SongArtists.Count());
                Console.WriteLine(song.Source.Name);
                Console.WriteLine(song.Source.Songs.Count());
            }*/

            // Concurrency
            // add [ConcurrencyCheck] attribute to the respective property

            // Deletion
            var song6 = db.Songs.Find(25);
            db.Songs.Remove(song6);
            db.SaveChanges();
        }

        class Projection
        {
            public string Name { get; set; }
            public DateTime? ModifiedOn { get; set; }
        }
    }
}
