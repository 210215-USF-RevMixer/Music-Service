using MusicBL;
using MusicModels;
using MusicREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UploadMusicTests
{
    public class CommentsControllerTest
    {
        private Mock<IUploadMusicBL> _mixerBLMock;

        public CommentsControllerTest()
        {
            _mixerBLMock = new Mock<IUploadMusicBL>();
        }
        [Fact]
        public async Task GetCommentsAsyncShouldReturnComments()
        {
            //arrange
            Comments comments = new Comments();
            _mixerBLMock.Setup(i => i.GetCommentsAsync());
            CommentsController commentsController = new CommentsController(_mixerBLMock.Object);

            //act 
            var result = await commentsController.GetCommentsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        //commented out because doesn't exist yet
        //  [Fact]
        // public async Task GetCommentByIdShouldGetComment()
        // {
        //     var commentId = 1;
        //     List<Comments> comment = new List<Comments> { new Comments { Id = commentId } };
        //     _mixerBLMock.Setup(x => x.GetCommentsByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(comment));
        //     var commentController = new CommentsController(_mixerBLMock.Object);
        //     var result = await commentController.GetCommentsByIDAsync(commentId);
        //     Assert.Equal(commentId, ((List<Comments>)((OkObjectResult)result).Value)[0].Id);
        //     _mixerBLMock.Verify(x => x.GetCommentsByIDAsync(commentId));
        // }
       [Fact]
        public async Task GetCommentByMusicIdShouldGetComment()
        {
            var commentId = 1;
            List<Comments> comment = new List<Comments> { new Comments { UploadMusicId = commentId } };
            _mixerBLMock.Setup(x => x.GetCommentsByMusicIDAsync(It.IsAny<int>())).Returns(Task.FromResult(comment));
            var commentController = new CommentsController(_mixerBLMock.Object);
            var result = await commentController.GetCommentsByMusicIDAsync(commentId);
            Assert.Equal(commentId, ((List<Comments>)((OkObjectResult)result).Value)[0].UploadMusicId);
            _mixerBLMock.Verify(x => x.GetCommentsByMusicIDAsync(commentId));
        }
        [Fact]
        public async Task AddCommentShouldAddComment()
        {
            var comment = new Comments();
            _mixerBLMock.Setup(x => x.AddCommentAsync(It.IsAny<Comments>())).Returns(Task.FromResult<Comments>(comment));
            var commentsController = new CommentsController(_mixerBLMock.Object);
            var result = await commentsController.AddCommentAsync(new Comments());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixerBLMock.Verify(x => x.AddCommentAsync((It.IsAny<Comments>())));
        }
         [Fact]
        public async Task UpdateCommentShouldUpdateComment()
        {
            var comment = new Comments { Id = 1, Comment = "First Comment" };
            _mixerBLMock.Setup(x => x.UpdateCommentAsync(It.IsAny<Comments>())).Returns(Task.FromResult(comment));
            var commentsController = new CommentsController(_mixerBLMock.Object);
            var result = await commentsController.UpdateCommentAsync(comment.Id, comment);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixerBLMock.Verify(x => x.UpdateCommentAsync(comment));

        }
        // [Fact]
        // public async Task UpdateCommentShouldUpdateComment()
        // {
        //     var comment = new Comments { Id = 1 };
        //     _mixerBLMock.Setup(x => x.UpdateCommentAsync(It.IsAny<Comments>())).Returns(Task.FromResult(comment));
        //     var commentsController = new CommentsController(_mixerBLMock.Object);
        //     var result = await commentsController.UpdateCommentAsync(comment.Id, comment);
        //     Assert.IsAssignableFrom<NoContentResult>(result);
        //     _mixerBLMock.Verify(x => x.UpdateCommentAsync(comment));

        // }

    }
}