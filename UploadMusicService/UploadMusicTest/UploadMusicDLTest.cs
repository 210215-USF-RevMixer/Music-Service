using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using UploadMusicDL;
using UploadMusicModels;
using Microsoft.EntityFrameworkCore;
namespace UploadMusicTest
{
    public class UploadMusicDLTest() 
    {
        private readonly DbContextOptions<DBCONTEXT> options;

        public UploadMusicDLTest()
        {
            options = new DbContextOptionsBuilder<DBCONTEXT>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();
        }

        [Fact]
        public async void GetAllUploadedMusicAsyncShouldReturnAllUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var uploadedMusic = await _repo.GetAllUploadedMusicAsync();
                Assert.Equal(2, uploadedMusic.Count);
            }
        }

        private void Seed()
        {
            //add 2 uploadedmusic objects
        }
    }
}