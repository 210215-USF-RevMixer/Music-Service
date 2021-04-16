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
    public class PlaylistControllerTest
    {
        private Mock<IUploadMusicBL> _mixBLMock;

        public PlaylistControllerTest()
        {
            _mixBLMock = new Mock<IUploadMusicBL>();
        }
        [Fact]
        public async Task GetPlayListsAsyncShouldReturnPlayLists()
        {
            //arrange
            PlayList playList = new PlayList();
            _mixBLMock.Setup(i => i.GetPlayListsAsync());
            PlayListController playListController = new PlayListController(_mixBLMock.Object);

            //act 
            var result = await playListController.GetPlayListsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetPlayListByIdShouldGetPlayList()
        {
            var playListId = 1;
            var playList = new PlayList { Id = playListId };
            _mixBLMock.Setup(x => x.GetPlayListByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(playList));
            var playListController = new PlayListController(_mixBLMock.Object);
            var result = await playListController.GetPlaylistByIDAsync(playListId);
            Assert.Equal(playListId, ((PlayList)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetPlayListByIDAsync(playListId));
        }
         [Fact]
        public async Task AddPlayListShouldAddPlayList()
        {
            var playList = new PlayList();
            _mixBLMock.Setup(x => x.AddPlayListAsync(It.IsAny<PlayList>())).Returns(Task.FromResult<PlayList>(playList));
            var playlistController = new PlayListController(_mixBLMock.Object);
            var result = await playlistController.AddPlaylistAsync(new PlayList());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixBLMock.Verify(x => x.AddPlayListAsync((It.IsAny<PlayList>())));
        }
         [Fact]
        public async Task DeletePlayListShouldDeletePlayList()
        {
            var playList = new PlayList{Id = 1};
            _mixBLMock.Setup(x => x.DeletePlayListAsync(It.IsAny<PlayList>())).Returns(Task.FromResult<PlayList>(playList));
            var playlistController = new PlayListController(_mixBLMock.Object);
            var result = await playlistController.DeletePlayListAsync(playList.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.DeletePlayListAsync((It.IsAny<PlayList>())));
        }
        [Fact]
        public async Task UpdatePlaylistShouldUpdatePlaylist()
        {
            var list = new PlayList { Id = 1 };
            _mixBLMock.Setup(x => x.UpdatePlayListAsync(It.IsAny<PlayList>())).Returns(Task.FromResult(list));
            var playController = new PlayListController(_mixBLMock.Object);
            var result = await playController.UpdatePlayListAsync(list.Id, list);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.UpdatePlayListAsync(list));

        }
     
    }
}