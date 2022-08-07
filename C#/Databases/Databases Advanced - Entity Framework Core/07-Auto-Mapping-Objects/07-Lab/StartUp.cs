using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07_Lab_Demo.MapperProfiles;
using _07_Lab_Demo.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;

namespace _07_Lab_Demo
{
    public class StartUp
    {
        public static void Main()
        {
            // dotnet ef dbcontext scaffold "Server=.;Database=MusicX;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
            var config = new MapperConfiguration(config =>
            {
                // create map profile
                config.AddProfile<SongInfoDtoProfile>();
                // Create inline map
                config.CreateMap<Song, SongNameDto>();
            });

            var mapper = config.CreateMapper();

            var db = new MusicXContext();
            Song song = db.Songs
                .FirstOrDefault(x => x.Id == 4);

            var songDto = mapper.Map<SongInfoDto>(song);
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(JsonConvert.SerializeObject(songDto, Formatting.Indented));
            Console.WriteLine();

            var songNameDto = mapper.Map<SongNameDto>(song);
            Console.WriteLine(JsonConvert.SerializeObject(songNameDto, Formatting.Indented));
            Console.WriteLine();

            var songs = db.Songs.Where(x => x.Name.StartsWith("Nik"))
                .ProjectTo<SongInfoDto>(config)
                .ToList();
            Console.WriteLine(JsonConvert.SerializeObject(songs,Formatting.Indented));
            Console.WriteLine();

            // using Reverse Map to create a song into the DB
            /*SongInfoDto songDtoNewSong = new SongInfoDto
            {
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                Name = "New song 2022 Automapper",
                SourceName = "SoftUni",
            };

            Song dbSong = mapper.Map<Song>(songDtoNewSong);
            db.Songs.Add(dbSong);
            db.SaveChanges();*/
        }
    }

    class SongNameDto
    {
        public string Name { get; set; }
    }

    class SongInfoDto
    {
        // custom mapping for Artists
        public string Artists { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string SearchTerms { get; set; }
        public string SourceName { get; set; }
        public int SongArtistsCount { get; set; }
        public bool IsDeleted { get; set; }


    }
}
