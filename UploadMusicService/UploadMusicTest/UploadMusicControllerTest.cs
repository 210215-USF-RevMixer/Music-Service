using MusicBL;
using MusicModels;
using UploadMusicREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UploadMusicTest
{
    public class UploadMusicControllerTest
    {
        private Mock<IUploadMusicBL> _mixerBLMock;

        public UploadMusicControllerTest()
        {
            _mixerBLMock = new Mock<IUploadMusicBL>();
        }
        [Fact]
        public async Task GetUploadMusicAsyncShouldReturnUploadMusic()
        {
            //arrange
            UploadMusic uploadMusic = new UploadMusic();
            _mixerBLMock.Setup(i => i.GetUploadedMusicAsync());
            UploadMusicController uploadMusicController = new UploadMusicController(_mixerBLMock.Object);

            //act 
            var result = await uploadMusicController.GetUploadedMusicAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetUploadByIdShouldGetUploadMusic()
        {
            var uploadMusicId = 1;
            var uploadMusic = new UploadMusic { Id = uploadMusicId };
            _mixerBLMock.Setup(x => x.GetUploadedMusicByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(uploadMusic));
            var uploadMusicController = new UploadMusicController(_mixerBLMock.Object);
            var result = await uploadMusicController.GetUploadedMusicByIDAsync(uploadMusicId);
            Assert.Equal(uploadMusicId, ((UploadMusic)((OkObjectResult)result).Value).Id);
            _mixerBLMock.Verify(x => x.GetUploadedMusicByIDAsync(uploadMusicId));
        }
         [Fact]
        public async Task GetUploadByUserIdShouldGetUploadMusic()
        {
            var uploadMusicId = 1;
            var uploadMusic = new UploadMusic { UserId = uploadMusicId };
            _mixerBLMock.Setup(x => x.GetUploadedMusicByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(uploadMusic));
            var uploadMusicController = new UploadMusicController(_mixerBLMock.Object);
            var result = await uploadMusicController.GetUploadedMusicByIDAsync(uploadMusicId);
            Assert.Equal(uploadMusicId, ((UploadMusic)((OkObjectResult)result).Value).UserId);
            _mixerBLMock.Verify(x => x.GetUploadedMusicByIDAsync(uploadMusicId));
        }
        [Fact]
        public async Task AddUploadMusicShouldAddUploadMusic()
        {
            var uploadMusic = new UploadMusic();
            _mixerBLMock.Setup(x => x.AddUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(uploadMusic));
            var uploadMusicController = new UploadMusicController(_mixerBLMock.Object);
            var result = await uploadMusicController.AddUploadedMusicAsync(new UploadMusic());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixerBLMock.Verify(x => x.AddUploadedMusicAsync((It.IsAny<UploadMusic>())));
        }
        [Fact]
        public async Task DeleteUploadMusicShouldDeleteUploadMusic()
        {
            var uploadMusic = new UploadMusic { Id = 1 };
            _mixerBLMock.Setup(x => x.DeleteUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(uploadMusic));
            var uploadMusicController = new UploadMusicController(_mixerBLMock.Object);
            var result = await uploadMusicController.DeleteUploadedMusicAsync(uploadMusic.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixerBLMock.Verify(x => x.DeleteUploadedMusicAsync((It.IsAny<UploadMusic>())));
        }
        [Fact]
        public async Task UpdateUploadMusicShouldUpdateUploadMusic()
        {
            var uploadMusic = new UploadMusic { Id = 1 };
            _mixerBLMock.Setup(x => x.UpdateUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult(uploadMusic));
            var uploadMusicController = new UploadMusicController(_mixerBLMock.Object);
            var result = await uploadMusicController.UpdateUploadedMusicAsync(uploadMusic.Id, uploadMusic);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixerBLMock.Verify(x => x.UpdateUploadedMusicAsync(uploadMusic));

        }

    }
}
