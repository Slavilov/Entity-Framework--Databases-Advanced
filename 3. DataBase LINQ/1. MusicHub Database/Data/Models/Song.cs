using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models 
{
    public class Song
    {
        public Song()
        {
            this.Performers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public decimal Price { get; set; }

        public ICollection<SongPerformer> Performers { get; set; }
    }
}