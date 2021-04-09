
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using UploadMusicBL;
using UploadMusicModels;
using UploadMusicREST.Controllers;

namespace MixerTests
{
    public class UploadedMusicControllerTest
    {
        private Mock<IUploadMusicBL> _uploadMusicBLMock;

        public UploadedMusicControllerTest()
        {
            _uploadMusicBLMock = new Mock<IUploadMusicBL>();
        }



        [Fact]
        public async Task DeleteUploadedMusicAsync_ShouldReturnStatusCode500_WhenInvalid()
        {
            //arrange
            int uploadMusicID = -2;
            UploadMusic uploadMusic = null;
            _uploadMusicBLMock.Setup(x => x.DeleteUploadedMusicAsync(uploadMusic)).Throws(new Exception());
            UploadMusicController uploadedMusicController = new UploadMusicController(_uploadMusicBLMock.Object);

            //act
            var result = await uploadedMusicController.DeleteUploadedMusicAsync(uploadMusicID);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            //  Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(500, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task GetUploadedMusicById_ShouldReturnOKObjectResult_WhenIDIsValid()
        {
            //arrange
            int uploadMusicId = 1;
            UploadMusic uploadedMusic = new UploadMusic();
            _uploadMusicBLMock.Setup(x => x.GetUploadedMusicByIDAsync(uploadMusicId)).ReturnsAsync(uploadedMusic);
            UploadMusicController uploadedMusicController = new UploadMusicController(_uploadMusicBLMock.Object);

            //act
            var result = await uploadedMusicController.GetUploadedMusicByIDAsync(uploadMusicId);

            //assert
            Assert.IsType<OkObjectResult>(result);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            _uploadMusicBLMock.Verify(x => x.GetUploadedMusicByIDAsync(uploadMusicId));
        }

        [Fact]
        public async Task DeleteUploadedMusicAsync_ShouldReturnNoContent_WhenUploadMusicIsValid()
        {
            //arrange
            int uploadedMusicID = 1;
            UploadMusic uploadMusic = new UploadMusic();
            _uploadMusicBLMock.Setup(x => x.DeleteUploadedMusicAsync(uploadMusic)).ReturnsAsync(uploadMusic);
            UploadMusicController uploadedMusicController = new UploadMusicController(_uploadMusicBLMock.Object);

            //act
            var result = await uploadedMusicController.DeleteUploadedMusicAsync(uploadedMusicID);

            //assert
            Assert.IsType<NoContentResult>(result);
            // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }


        [Fact]
        public async Task GetUploadedMusicByUserIdAsync_ShouldReturn_OKObjectResult_WhenIDIsValid()
        {
            //arrange
            int userID = 2;
            UploadMusic uploadMusic = new UploadMusic();
            _uploadMusicBLMock.Setup(x => x.GetUploadedMusicByIDAsync(userID)).ReturnsAsync(uploadMusic);
            UploadMusicController uploadedMusicController = new UploadMusicController(_uploadMusicBLMock.Object);

            //act
            var result = await uploadedMusicController.GetUploadedMusicByIDAsync(userID);

            //assert
            Assert.IsType<OkObjectResult>(result);
            // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [Fact]
        public async Task GetUploadedMusicByUserIdAsync_ShouldReturnNotFound_WhenUploadMusicIsNull()
        {
            //arrange
            int userID = 2;
            UploadMusic uploadMusic = null;
            _uploadMusicBLMock.Setup(x => x.GetUploadedMusicByIDAsync(userID)).ReturnsAsync(uploadMusic);
            UploadMusicController uploadedMusicController = new UploadMusicController(_uploadMusicBLMock.Object);

            //act
            var result = await uploadedMusicController.GetUploadedMusicByIDAsync(userID);

            //assert
            Assert.IsType<NotFoundResult>(result);
            // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [Fact]
        public async Task GetUploadedMusicAsync_ShouldReturnOkObjectResult()
        {
            //arrange
            List<UploadMusic> uploadMusics = new List<UploadMusic>();
            _uploadMusicBLMock.Setup(x => x.GetUploadedMusicAsync()).ReturnsAsync(uploadMusics);
            UploadMusicController uploadedMusicController = new UploadMusicController(_uploadMusicBLMock.Object);

            //act
            var result = await uploadedMusicController.GetUploadedMusicAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
            // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


    }
}