using MusicBL;
using MusicDL;
using MusicModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UploadMusicTest
{
    public class UploadMusicBLTests
    {
        private Mock<IMusicRepoDB> _musicBLMock;

        public UploadMusicBLTests()
        {
            _musicBLMock = new Mock<IMusicRepoDB>();
        }
        [Fact]
        public async Task GetUploadedMusicAsyncShouldGetUploadedMusic()
        {
            //var newUpload = new UploadMusic();
            var uploads = new List<UploadMusic> { new UploadMusic() { Id = 1 } };
            _musicBLMock.Setup(x => x.GetUploadedMusicAsync());
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            //var newUpload = await newMusicBL.AddUploadedMusicAsync(upload);
            var result = await newMusicBL.GetUploadedMusicAsync();
            Assert.Equal(1, uploads.Count);
            _musicBLMock.Verify(x => x.GetUploadedMusicAsync());

        }
        [Fact]
        public async Task GetUploadedMusicByIdAsyncShouldGetUploadedMusic()
        {
            var uploadId = 1;
            var newUpload = new UploadMusic();
            _musicBLMock.Setup(x => x.GetUploadedMusicByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<UploadMusic>(newUpload));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.GetUploadedMusicByIDAsync(uploadId);
            Assert.Equal(result, newUpload);
            _musicBLMock.Verify(x => x.GetUploadedMusicByIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task GetUploadedMusicByUserIdAsyncShouldGetUploadedMusic()
        {
            int id = 1;
            List<UploadMusic> uploads = new List<UploadMusic>{ new UploadMusic {UserId = id} };
            _musicBLMock.Setup(x => x.GetUploadedMusicByUserIDAsync(It.IsAny<int>())).Returns(Task.FromResult(uploads));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.GetUploadedMusicByUserIDAsync(id);
            Assert.Equal(result, uploads);
            _musicBLMock.Verify(x => x.GetUploadedMusicByUserIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task AddUploadedMusicAsyncShouldAddUploadedMusic()
        {
            var newUpload = new UploadMusic { Name = "Test", MusicFilePath = "Test" };
            _musicBLMock.Setup(x => x.AddUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(newUpload));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.AddUploadedMusicAsync(newUpload);
            Assert.Equal(result, newUpload);
            _musicBLMock.Verify(x => x.AddUploadedMusicAsync(It.IsAny<UploadMusic>()));

        }
        [Fact]
        public async Task DeleteUploadedMusicAsyncShouldDeleteUploadedMusic()
        {
            var newUpload = new UploadMusic();
            _musicBLMock.Setup(x => x.DeleteUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(newUpload));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.DeleteUploadedMusicAsync(newUpload);
            Assert.Equal(result, newUpload);
            _musicBLMock.Verify(x => x.DeleteUploadedMusicAsync(It.IsAny<UploadMusic>()));

        }
        [Fact]
        public async Task UpdateUploadedMusicAsyncShouldUpdateUploadedMusic()
        {
            var newUpload = new UploadMusic();
            _musicBLMock.Setup(x => x.UpdateUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(newUpload));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.UpdateUploadedMusicAsync(newUpload);
            Assert.Equal(result, newUpload);
            _musicBLMock.Verify(x => x.UpdateUploadedMusicAsync(It.IsAny<UploadMusic>()));

        }
    }
}