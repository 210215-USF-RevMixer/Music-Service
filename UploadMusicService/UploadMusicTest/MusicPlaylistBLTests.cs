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
    public class MusicPlaylistBLTests
    {
        private Mock<IMusicRepoDB> _musicBLMock;

        public MusicPlaylistBLTests()
        {
            _musicBLMock = new Mock<IMusicRepoDB>();
        }
           [Fact]
        public async Task GetMusicPlaylistsAsyncShouldGetMusicPlaylists()
        {
            //var musicPlaylist = new MusicPlaylist();
            var musicPlaylists = new List<MusicPlaylist> {new MusicPlaylist(){Id = 1}};
            _musicBLMock.Setup(x => x.GetMusicPlaylistsAsync());
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            //var newMusicPlaylist = await newMusicBL.AddMusicPlaylistAsync(musicPlaylist);
            var result = await newMusicBL.GetMusicPlaylistsAsync();
            Assert.Equal(1, musicPlaylists.Count);
            _musicBLMock.Verify(x => x.GetMusicPlaylistsAsync());

        }
        [Fact]
        public async Task GetMusicPlaylistByIdAsyncShouldGetMusicPlaylist()
        {
            var musicPlaylistId = 1;
            var newMusicPlaylist = new MusicPlaylist();
            _musicBLMock.Setup(x => x.GetMusicPlaylistByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<MusicPlaylist>(newMusicPlaylist));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.GetMusicPlaylistByIDAsync(musicPlaylistId);
            Assert.Equal(result, newMusicPlaylist);
            _musicBLMock.Verify(x => x.GetMusicPlaylistByIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task AddMusicPlaylistAsyncShouldAddMusicPlaylist()
        {
            var newMusicPlaylist = new MusicPlaylist();
            _musicBLMock.Setup(x => x.AddMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult<MusicPlaylist>(newMusicPlaylist));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.AddMusicPlaylistAsync(newMusicPlaylist);
            Assert.Equal(result, newMusicPlaylist);
            _musicBLMock.Verify(x => x.AddMusicPlaylistAsync(It.IsAny<MusicPlaylist>()));

        }
        [Fact]
        public async Task DeleteMusicPlaylistAsyncShouldDeleteMusicPlaylist()
        {
            var newMusicPlaylist = new MusicPlaylist();
            _musicBLMock.Setup(x => x.DeleteMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult<MusicPlaylist>(newMusicPlaylist));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.DeleteMusicPlaylistAsync(newMusicPlaylist);
            Assert.Equal(result, newMusicPlaylist);
            _musicBLMock.Verify(x => x.DeleteMusicPlaylistAsync(It.IsAny<MusicPlaylist>()));

        }
        [Fact]
        public async Task UpdateMusicPlaylistAsyncShouldUpdateMusicPlaylist()
        {
            var newMusicPlaylist = new MusicPlaylist();
            _musicBLMock.Setup(x => x.UpdateMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult<MusicPlaylist>(newMusicPlaylist));
            var newMusicBL = new UploadedMusicBL(_musicBLMock.Object);
            var result = await newMusicBL.UpdateMusicPlaylistAsync(newMusicPlaylist);
            Assert.Equal(result, newMusicPlaylist);
            _musicBLMock.Verify(x => x.UpdateMusicPlaylistAsync(It.IsAny<MusicPlaylist>()));

        }
    }
}