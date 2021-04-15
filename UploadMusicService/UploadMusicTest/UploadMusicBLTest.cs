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
            databaseMock.Setup(db => db.GetCommentsAsync()).Returns(Task.FromResult<List<Comments>>(comments));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.GetCommentsAsync();

            Assert.NotNull(result);
            Assert.Equal(2, comments.Count());
            databaseMock.Verify(db => db.GetCommentsAsync());
        }

        [Fact]
        public async Task GetCommentByIDAsyncShouldReturnTheCorrectComment()
        {
            var comment = new Comments() { Id = 1024, Comment = "test" };
            databaseMock.Setup(db => db.GetCommentByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<Comments>(comment));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.GetCommentByIDAsync(1024);

            Assert.NotNull(result);
            Assert.Equal("test", result.Comment);
            databaseMock.Verify(db => db.GetCommentByIDAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task GetCommentsByMusicIDShouldReturnCorrectComments()
        {
            var comments = new List<Comments>
            {
                new Comments() { Id = 1, UploadMusicId = 10 },
                new Comments() { Id = 3, UploadMusicId = 10 }
            };
            databaseMock.Setup(db => db.GetCommentsByMusicIDAsync(It.IsAny<int>())).Returns(Task.FromResult<List<Comments>>(comments));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.GetCommentsByMusicIDAsync(10);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(10, result.FirstOrDefault().UploadMusicId);
            databaseMock.Verify(db => db.GetCommentsByMusicIDAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task AddCommentAsyncShouldReturnTheComment()
        {
            var comment = new Comments() { Id = 5, Comment = "shrimp heaven now" };
            databaseMock.Setup(db => db.AddCommentAsync(It.IsAny<Comments>())).Returns(Task.FromResult<Comments>(comment));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.AddCommentAsync(comment);

            Assert.NotNull(result);
            Assert.Equal("shrimp heaven now", result.Comment);
            databaseMock.Verify(db => db.AddCommentAsync(It.IsAny<Comments>()));
        }

        [Fact]
        public async Task DeleteCommentAsyncShouldReturnTheDeletedComment()
        {
            var comment = new Comments() { Id = 5, Comment = "shrimp heaven now" };
            databaseMock.Setup(db => db.DeleteCommentAsync(It.IsAny<Comments>())).Returns(Task.FromResult<Comments>(comment));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.DeleteCommentAsync(comment);

            Assert.NotNull(result);
            Assert.Equal("shrimp heaven now", result.Comment);
            databaseMock.Verify(db => db.DeleteCommentAsync(It.IsAny<Comments>()));
        }

        [Fact]
        public async Task UpdateCommentAsyncShouldReturnTheUpdatedComment()
        {
            var comment = new Comments() { Id = 5, Comment = "shrimp heaven now" };
            databaseMock.Setup(db => db.UpdateCommentAsync(It.IsAny<Comments>())).Returns(Task.FromResult<Comments>(comment));
            var newMusicBL = new UploadedMusicBL(databaseMock.Object);

            var result = await newMusicBL.UpdateCommentAsync(comment);

            Assert.NotNull(result);
            Assert.Equal("shrimp heaven now", result.Comment);
            databaseMock.Verify(db => db.UpdateCommentAsync(It.IsAny<Comments>()));
        }


    }
}