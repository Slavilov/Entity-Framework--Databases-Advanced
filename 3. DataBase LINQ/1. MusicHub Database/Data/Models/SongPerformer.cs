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
    public class SongPerformer
    {
        public int SongId { get; set; }
        public Song Song { get; set; }

        public int PerfomerId { get; set; }
        public Performer Performer { get; set; }

        //Tova e Mapping Tablica

        //One Song can have many Performers
        //One Permormer can have many Songs

    }
}