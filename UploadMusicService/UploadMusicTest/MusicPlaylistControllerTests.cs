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
    public class MusicPlaylistControllerTest
    {
        private Mock<IUploadMusicBL> _mixBLMock;

        public MusicPlaylistControllerTest()
        {
            _mixBLMock = new Mock<IUploadMusicBL>();
        }
        [Fact]
        public async Task GetMusicPlaylistsAsyncShouldReturnMusicPlaylists()
        {
            //arrange
            MusicPlaylist playList = new MusicPlaylist();
            _mixBLMock.Setup(i => i.GetMusicPlaylistsAsync());
            MusicPlaylistController playListController = new MusicPlaylistController(_mixBLMock.Object);

            //act 
            var result = await playListController.GetMusicPlaylistsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetMusicPlaylistByIdShouldGetMusicPlaylist()
        {
            var playListId = 1;
            var playList = new MusicPlaylist { Id = playListId };
            _mixBLMock.Setup(x => x.GetMusicPlaylistByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(playList));
            var playListController = new MusicPlaylistController(_mixBLMock.Object);
            var result = await playListController.GetMusicPlaylistByIDAsync(playListId);
            Assert.Equal(playListId, ((MusicPlaylist)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetMusicPlaylistByIDAsync(playListId));
        }
        [Fact]
        public async Task AddMusicPlaylistShouldAddMusicPlaylist()
        {
            var playList = new MusicPlaylist();
            _mixBLMock.Setup(x => x.AddMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult<MusicPlaylist>(playList));
            var playlistController = new MusicPlaylistController(_mixBLMock.Object);
            var result = await playlistController.AddMusicPlaylistAsync(new MusicPlaylist());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixBLMock.Verify(x => x.AddMusicPlaylistAsync((It.IsAny<MusicPlaylist>())));
        }
        [Fact]
        public async Task DeleteMusicPlaylistShouldDeleteMusicPlaylist()
        {
            var playList = new MusicPlaylist { Id = 1 };
            _mixBLMock.Setup(x => x.DeleteMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult<MusicPlaylist>(playList));
            var playlistController = new MusicPlaylistController(_mixBLMock.Object);
            var result = await playlistController.DeleteMusicPlaylistAsync(playList.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.DeleteMusicPlaylistAsync((It.IsAny<MusicPlaylist>())));
        }
        [Fact]
        public async Task UpdateMusicPlaylistShouldUpdateMusicPlaylist()
        {
            var list = new MusicPlaylist { Id = 1 };
            _mixBLMock.Setup(x => x.UpdateMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult(list));
            var playController = new MusicPlaylistController(_mixBLMock.Object);
            var result = await playController.UpdateMusicPlaylistAsync(list.Id, list);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.UpdateMusicPlaylistAsync(list));

        }

    }
}