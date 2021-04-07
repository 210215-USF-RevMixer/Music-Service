using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UploadMusicModels;

namespace UploadMusicDL
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadMusic>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
