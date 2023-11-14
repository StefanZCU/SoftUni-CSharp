namespace MusicHub
{
    using System;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Problem 02.
            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            //Problem 03.
            //Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        //Problem 02.

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var allAlbumInfo = context.Albums
                .Where(x => x.ProducerId.HasValue && x.ProducerId == producerId)
                .ToArray()
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                        .OrderByDescending(x => x.Name)
                        .ThenBy(x => x.Writer)
                        .Select(s => new
                        {
                            s.Name,
                            s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .ToList(),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();

            foreach (var album in allAlbumInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int counter = 1;

                foreach (var albumSong in album.AlbumSongs)
                {
                    sb
                        .AppendLine($"---#{counter}")
                        .AppendLine($"---SongName: {albumSong.Name}")
                        .AppendLine($"---Price: {albumSong.Price:F2}")
                        .AppendLine($"---Writer: {albumSong.SongWriter}");

                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");

                counter = 1;
            }

            return sb.ToString().TrimEnd();
                
        }

        //Problem 03.
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songAboveGivenDuration = context.Songs
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    Performer = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToList(),
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ToList();

            int counter = 1;
            foreach (var song in songAboveGivenDuration)
            {
                sb
                    .AppendLine($"-Song #{counter}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}");
                foreach (var performer in song.Performer)
                {
                    sb
                        .AppendLine($"---Performer: {performer}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
