//namespace MusicHub
//{
//    using System;
//    using System.Linq;
//    using System.Text;
//    using Data;
//    using Initializer;
//
//    public class StartUp
//    {
//        public static void Main(string[] args)
//        {
//            MusicHubDbContext context =
//                new MusicHubDbContext();
//
//            DbInitializer.ResetDatabase(context);
//
//            var result = ExportAlbumsInfo(context, 9);
//            Console.WriteLine(result);
//            //Test your solutions here
//        }
//
//        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
//        {
//            var albums = context.Albums
//                .Where(x => x.ProducerId == producerId);
//
//            var sb = new StringBuilder();
//
//            foreach (var album in albums)
//            {
//                sb.AppendLine($"-AlbumName: {album.Name}");
//                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}");
//                sb.AppendLine($"-ProducerName: {album.Producer.Name}");
//                sb.AppendLine($"-Songs:");
//
//                album.Songs
//                    .OrderByDescending(x => x.Name)
//                    .ThenBy(x => x.Writer);
//
//                int i = 0;
//                foreach (var song in album.Songs)
//                {
//                    i++;
//                    sb.AppendLine($"---#{i}");
//                    sb.AppendLine($"---SongName: {song.Name}");
//                    sb.AppendLine($"---Price: {song.Price:F2}");
//                    sb.AppendLine($"---Writer: {song.Writer}");
//                }
//                sb.AppendLine($"-AlbumPrice: {album.Songs.Sum(x => x.Price):F2}");
//                sb.AppendLine($" ");
//            }
//            return sb.ToString();
//        }
//
//        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
