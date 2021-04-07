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
        private readonly DbContextOptions<RevMixerDBContext> options;

        public UploadMusicDLTest()
        {
            options = new DbContextOptionsBuilder<RevMixerDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();
        }

        [Fact]
        public async void GetAllUploadedMusicAsyncShouldReturnAllUploadedMusic()
        {
            using (var context = new RevMixerDBContext(options))
            {
                IMixerRepoDB _repo = new RevMixerRepoDB(context);

                var uploadedMusic = await _repo.GetAllUploadedMusicAsync();
                Assert.Equal(2, uploadedMusic.Count);
            }
        }

        [Fact]
        public async void AddUploadedMusicAsyncShouldAddUploadedMusic()
        {
            using (var context = new RevMixerDBContext(options))
            {
                IMixerRepoDB _repo = new RevMixerRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic {
                    UserId = 1,
                    MusicFilePath = "cool_song",
                    Name = "Jumping Jacks",
                    UploadDate = DateTime.Parse("2021-03-15 18:17:00"),
                    Likes = 3409,
                    Plays = 9084
                };

                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
            }

            using (var assertContext = new RevMixerDBContext(options))
            {
                var result = assertContext.UploadMusic.Select(c => c).OrderBy(c => c.UserId).FirstOrDefaultAsync();

                Assert.NotNull(result.Result);
                Assert.Equal("Name", result.Result.Name);
            }
        }

        private void Seed()
        {
            //add 2 uploadedmusic objects
        }
    }
}