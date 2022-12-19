using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data 
{
    public class MusicHubContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=USER150407-1\\SQLEXPRESS;database=MusicHub;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>(x =>
            {
                x.HasKey(x => new { x.SongId, x.PerfomerId });
            });
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set;}
        public DbSet<Writer> Writers { get; set; }
    }
}
