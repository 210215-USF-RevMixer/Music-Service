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
    public class PlayListBLTests
    {
        private Mock<IMusicRepoDB> _musicBLMock;

        public PlayListBLTests()
        {
            _musicBLMock = new Mock<IMusicRepoDB>();
        }
           [Fact]
        public async Task GetPlayListsAsyncShouldGetPlayLists()
        {
            //var PlayList = new PlayList();
            var playLists = new List<PlayList> {new PlayList(){Id = 1}};
            _musicBLMock.Setup(x => x.GetPlayListsAsync());
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            //var newPlayList = await newMusicBL.AddPlayListAsync(playList);
            var result = await newMusicBL.GetPlayListsAsync();
            Assert.Equal(1, playLists.Count);
            _musicBLMock.Verify(x => x.GetPlayListsAsync());

        }
        [Fact]
        public async Task GetPlayListByIdAsyncShouldGetPlayList()
        {
            var playListId = 1;
            var newPlayList = new PlayList();
            _musicBLMock.Setup(x => x.GetPlayListByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<PlayList>(newPlayList));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.GetPlayListByIDAsync(playListId);
            Assert.Equal(result, newPlayList);
            _musicBLMock.Verify(x => x.GetPlayListByIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task AddPlayListAsyncShouldAddPlayList()
        {
            var newPlayList = new PlayList();
            _musicBLMock.Setup(x => x.AddPlayListAsync(It.IsAny<PlayList>())).Returns(Task.FromResult<PlayList>(newPlayList));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.AddPlayListAsync(newPlayList);
            Assert.Equal(result, newPlayList);
            _musicBLMock.Verify(x => x.AddPlayListAsync(It.IsAny<PlayList>()));

        }
        [Fact]
        public async Task DeletePlayListAsyncShouldDeletePlayList()
        {
            var newPlayList = new PlayList();
            _musicBLMock.Setup(x => x.DeletePlayListAsync(It.IsAny<PlayList>())).Returns(Task.FromResult<PlayList>(newPlayList));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.DeletePlayListAsync(newPlayList);
            Assert.Equal(result, newPlayList);
            _musicBLMock.Verify(x => x.DeletePlayListAsync(It.IsAny<PlayList>()));

        }
        [Fact]
        public async Task UpdatePlayListAsyncShouldUpdatePlayList()
        {
            var newPlayList = new PlayList();
            _musicBLMock.Setup(x => x.UpdatePlayListAsync(It.IsAny<PlayList>())).Returns(Task.FromResult<PlayList>(newPlayList));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.UpdatePlayListAsync(newPlayList);
            Assert.Equal(result, newPlayList);
            _musicBLMock.Verify(x => x.UpdatePlayListAsync(It.IsAny<PlayList>()));

        }
    }
}