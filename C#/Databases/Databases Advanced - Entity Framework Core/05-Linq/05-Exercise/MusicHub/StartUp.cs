namespace MusicHub
{
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        // ALTER AUTHORIZATION ON DATABASE::[MusicHub] TO sa
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            // Console.WriteLine(ExportAlbumsInfo(context, 9));
            // Console.WriteLine(ExportSongsAboveDuration(context,4));

        }
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albumsInfo = context
                .Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy").Replace("-", "/"),
                    ProducerName = x.Producer.Name,
                    AlbumPrice = x.Price,
                    SongList = x.Songs
                        .Select( s => new
                        {
                            s.Name,
                            s.Price,
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer)
                        .ToArray()

                })
                .ToArray();

            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int counter = 0;

                foreach (var song in album.SongList)
                {
                    sb.AppendLine($"---#{++counter}")
                        .AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            var songList = context
                .Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    PerformerFullName = s.SongPerformers.Where(p => p.SongId == s.Id)
                        .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}").FirstOrDefault(), // TODO:
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration,

                })
                .ToArray()
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName);

            byte counter = 0;

            foreach (var song in songList)
            {
                sb.AppendLine($"-Song #{++counter}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
