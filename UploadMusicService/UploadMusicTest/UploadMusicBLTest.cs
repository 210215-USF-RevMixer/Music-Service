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
    public class UploadMusicBLTest {

        private Mock<IMusicRepoDB> databaseMock;

        public UploadMusicBLTest()
        {
            databaseMock = new Mock<IMusicRepoDB>();
        }

        [Fact]
        public async Task GetCommentsAsyncShouldReturnAllTheComments() 
        {
            var comments = new List<Comments> {new Comments(){Id = 1}, new Comments(){Id = 5}};
            databaseMock.Setup(db => db.GetCommentsAsync());
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.GetCommentsAsync();

            Assert.Equal(2, comments.Count());
            databaseMock.Verify(db => db.GetCommentsAsync());
        }

        [Fact]
        public async Task GetCommentByIDAsyncShouldReturnTheCorrectComment()
        {
            var comment = new Comments() { Id = 1024, Comment = "test" };
            databaseMock.Setup(db => db.GetCommentByIDAsync(It.IsAny<int>()));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.GetCommentByIDAsync(1024);

            Assert.NotNull(result);
            Assert.Equal("test", result.Comment);
        }


    }
}