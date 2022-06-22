namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            var res = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(res);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producer = context.Producers.FirstOrDefault(x => x.Id == producerId);
            var albums = producer.Albums.Select(x => new
            {
                AlbumName = x.Name,
                ReleasedDate = x.ReleaseDate,
                ProducerName = x.Producer.Name,
                TotalPrice = x.Price,
                AlbumSongs = x.Songs.Select(s => new
                {
                    SongName = s.Name,
                    SongPrice = s.Price,
                    SongWriter = s.Writer.Name
                }).OrderByDescending(a => a.SongName).ThenBy(a => a.SongWriter)
            }).OrderByDescending(a => a.TotalPrice)
            .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleasedDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                int counter = 1;
                foreach (var songs in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {songs.SongName}");
                    sb.AppendLine($"---Price: {songs.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {songs.SongWriter}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context
                .Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .FirstOrDefault(),
                    SongName = s.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .ToList()
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            var i = 1;
            foreach (var song in songs)
            {

                sb.AppendLine($"-Song #{i}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");

                i++;
            }

            return sb.ToString().Trim();

        }
    }
}
