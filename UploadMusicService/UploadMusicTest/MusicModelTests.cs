//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MusicModels;
using Xunit;
using System.Collections.Generic;

namespace UploadMusicTest
{
    public class MusicModelTests
    {
        private Comments testComment = new Comments();
        private MusicPlaylist testMusicPlaylist = new MusicPlaylist();
        private PlayList testPlayList = new PlayList();
        private UploadMusic testUploadMusic = new UploadMusic();
        //Comment tests
        #region 
        [Fact]
        public void CommentIdShouldBeSet()
        {

            int testId = 1;

            testComment.Id = testId;

            Assert.Equal(testId, testComment.Id);
        }
        [Fact]
        public void CommentCommentShouldBeSet()
        {

            string testCommentContents = "Test";

            testComment.Comment = testCommentContents;

            Assert.Equal(testCommentContents, testComment.Comment);
        }
        [Fact]
        public void CommentCommentDataShouldBeSet()
        {

            DateTime testCommentData = DateTime.Parse("2021-03-15 18:17:00");

            testComment.CommentData = testCommentData;

            Assert.Equal(testCommentData, testComment.CommentData);
        }
        [Fact]
        public void CommentUploadMusicIdShouldBeSet()
        {

            int testId = 1;

            testComment.UploadMusicId = testId;

            Assert.Equal(testId, testComment.UploadMusicId);
        }
        [Fact]
        public void CommentUserIdShouldBeSet()
        {

            int testId = 1;

            testComment.UserId = testId;

            Assert.Equal(testId, testComment.UserId);
        }
        [Fact]
        public void CommentUploadedMusicShouldBeSet()
        {
            var newComment = new Comments
            {
                Id = 1,
                Comment = "Test",
                UserId = 1,
                UploadMusicId = 1,
                UploadedMusic = new UploadMusic { Id = 1, UserId = 1, MusicFilePath = "test", Name = "Song" }
            };
            Assert.Equal("Song", newComment.UploadedMusic.Name);
        }
        #endregion
        //MusicPlaylist tests
        #region
        [Fact]
        public void MusicPlaylistIdShouldBeSet()
        {

            int testId = 1;

            testMusicPlaylist.Id = testId;

            Assert.Equal(testId, testMusicPlaylist.Id);
        }
        [Fact]
        public void MusicPlaylistPlayListIdShouldBeSet()
        {

            int testId = 1;

            testMusicPlaylist.PlayListId = testId;

            Assert.Equal(testId, testMusicPlaylist.PlayListId);
        }
        [Fact]
        public void MusicPlaylistMusicIdShouldBeSet()
        {

            int testId = 1;

            testMusicPlaylist.MusicId = testId;

            Assert.Equal(testId, testMusicPlaylist.MusicId);
        }
        [Fact]
        public void MusicPlayListPlayListShouldBeSet()
        {
            PlayList playList = new PlayList { Name = "Test" };
            testMusicPlaylist.PlayList = playList;
            Assert.Equal("Test", testMusicPlaylist.PlayList.Name);
        }
        [Fact]
        public void MusicPlayListUploadMusicShouldBeSet()
        {
            UploadMusic upload = new UploadMusic { Name = "Test" };
            testMusicPlaylist.UploadMusic = upload;
            Assert.Equal("Test", testMusicPlaylist.UploadMusic.Name);
        }
        #endregion
        //PlayList test
        #region 
        [Fact]
        public void PlayListIdShouldBeSet()
        {

            int testId = 1;

            testPlayList.Id = testId;

            Assert.Equal(testId, testPlayList.Id);
        }
        [Fact]
        public void PlayListUserIdShouldBeSet()
        {

            int testId = 1;

            testPlayList.UserId = testId;

            Assert.Equal(testId, testPlayList.UserId);
        }
        [Fact]
        public void PlayListNameShouldBeSet()
        {

            string testName = "Test";

            testPlayList.Name = testName;

            Assert.Equal(testName, testPlayList.Name);
        }
        [Fact]
        public void PlayListMusicPlaylistShouldHaveMusicPlaylists()
        {

            ICollection<MusicPlaylist> playListMusicPlaylist = new List<MusicPlaylist>();
            playListMusicPlaylist.Add(testMusicPlaylist);
            testPlayList.MusicPlaylist = playListMusicPlaylist;
            Assert.Equal(playListMusicPlaylist, testPlayList.MusicPlaylist);
        }
        #endregion
        //UploadMusic
        #region 
        [Fact]
        public void UploadMusicIdShouldBeSet()
        {

            int testId = 1;

            testUploadMusic.Id = testId;

            Assert.Equal(testId, testUploadMusic.Id);
        }
        [Fact]
        public void UploadMusicUserIdShouldBeSet()
        {

            int testId = 1;

            testUploadMusic.UserId = testId;

            Assert.Equal(testId, testUploadMusic.UserId);
        }
        [Fact]
        public void UploadMusicFilePathShouldBeSet()
        {

            string testFilePath = "1";

            testUploadMusic.MusicFilePath = testFilePath;

            Assert.Equal(testFilePath, testUploadMusic.MusicFilePath);
        }
        [Fact]
        public void UploadMusicNameShouldBeSet()
        {

            string testName = "Test";

            testUploadMusic.Name = testName;

            Assert.Equal(testName, testUploadMusic.Name);
        }
        [Fact]
        public void UploadMusicUploadDateShouldBeSet()
        {

            DateTime testTime = DateTime.Parse("2021-03-15 18:17:00");

            testUploadMusic.UploadDate = testTime;

            Assert.Equal(testTime, testUploadMusic.UploadDate);
        }
        [Fact]
        public void UploadMusicLikesShouldBeSet()
        {

            int testLikes = 1;

            testUploadMusic.Likes = testLikes;

            Assert.Equal(testLikes, testUploadMusic.Likes);
        }
        [Fact]
        public void UploadMusicPlaysShouldBeSet()
        {

            int testPlays = 1;

            testUploadMusic.Plays = testPlays;

            Assert.Equal(testPlays, testUploadMusic.Plays);
        }
        [Fact]
        public void UploadMusicIsPrivateShouldBeTrue()
        {

            bool testBool = true;

            testUploadMusic.IsPrivate = testBool;

            Assert.Equal(testBool, testUploadMusic.IsPrivate);
        }
        [Fact]
        public void UploadMusicIsApprovedShouldBeTrue()
        {

            bool testBool = true;

            testUploadMusic.IsApproved = testBool;

            Assert.Equal(testBool, testUploadMusic.IsApproved);
        }
        [Fact]
        public void UploadMusicIsLockedShouldBeTrue()
        {

            bool testBool = true;

            testUploadMusic.IsLocked = testBool;

            Assert.Equal(testBool, testUploadMusic.IsLocked);
        }
         [Fact]
        public void UploadMusicMusicPlaylistShouldHaveMusicPlaylists()
        {

            ICollection<MusicPlaylist> uploadMusicMusicPlaylist = new List<MusicPlaylist>();
            uploadMusicMusicPlaylist.Add(testMusicPlaylist);
            testUploadMusic.MusicPlaylists = uploadMusicMusicPlaylist;
            Assert.Equal(uploadMusicMusicPlaylist, testUploadMusic.MusicPlaylists);
        }
          [Fact]
        public void UploadMusicCommentsShouldHaveMusicComments()
        {

            ICollection<Comments> uploadMusicComments = new List<Comments>();
            uploadMusicComments.Add(testComment);
            testUploadMusic.Comments = uploadMusicComments;
            Assert.Equal(uploadMusicComments, testUploadMusic.Comments);
        }
        #endregion
    }
}
