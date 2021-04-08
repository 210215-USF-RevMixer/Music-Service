using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MusicModels;

namespace MusicDL
{
    public class UploadMusicDBContext : DbContext
    {
        public UploadMusicDBContext(DbContextOptions options) : base(options)
        {
        }

        protected UploadMusicDBContext()
        {
        }

        public DbSet<UploadMusic> UploadMusic { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadMusic>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlayList>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<MusicPlaylist>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
