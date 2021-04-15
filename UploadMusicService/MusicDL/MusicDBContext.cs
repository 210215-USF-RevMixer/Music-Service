using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MusicModels;

namespace MusicDL
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions options) : base(options)
        {
        }

        protected MusicDBContext()
        {
        }

        public DbSet<UploadMusic> UploadMusic { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylist { get; set; }

        public DbSet<Comments> Comments { get; set; }

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

            // relations
            modelBuilder.Entity<PlayList>()
               .HasMany(p => p.MusicPlaylist)
               .WithOne(mp => mp.PlayList)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UploadMusic>()
                .HasMany(um => um.MusicPlaylists)
                .WithOne(mp => mp.UploadMusic)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UploadMusic>()
                .HasMany(um => um.Comments)
                .WithOne(c => c.UploadedMusic)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
