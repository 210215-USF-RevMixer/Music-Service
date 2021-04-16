using Xunit;
using Microsoft.EntityFrameworkCore;
using MusicDL;
using Model = MusicModels;
using System.Linq;
using MusicModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace UploadMusicTests
{
    public class MusicRepoTest
    {
        private readonly DbContextOptions<MusicDBContext> options;
        public MusicRepoTest()
        {
            //use sqlite to create an inmemory test.db
            options = new DbContextOptionsBuilder<MusicDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }
        //Comment
        #region 
        [Fact]
        public async void GetCommentsAsyncShouldReturnAllComments()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);

                var comments = await _repo.GetCommentsAsync();
                Assert.Equal(2, comments.Count);
            }
        }
        [Fact]
        public async void GetCommentByIDAsyncShouldReturnComment()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);

                Comments testComment = new Comments();
                testComment.Id = 1;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var foundComment = await _repo.GetCommentByIDAsync(1);
                Assert.Equal(1, testComment.Id);
            }
        }
        [Fact]
        public async void GetCommentByMusicIDAsyncShouldReturnComment()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);

                Comments testComment = new Comments();
                testComment.Id = 1;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var foundComment = await _repo.GetCommentsByMusicIDAsync(1);
                Assert.Equal(1, testComment.Id);
            }
        }
        [Fact]
        public async void AddCommentAsyncShouldAddComment()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                Comments testComment = new Comments();
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var newComment = await _repo.AddCommentAsync(testComment);
                Assert.Equal("First Comment", newComment.Comment);
            }
        }
        [Fact]
        public async void DeleteCommentAsyncShouldDeleteComment()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                Comments testComment = new Comments();
                testComment.Id = 4;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var newComment = await _repo.AddCommentAsync(testComment);
                var deletedComment = await _repo.DeleteCommentAsync(testComment);
                using (var assertContext = new MusicDBContext(options))
                {
                    var result = await _repo.GetCommentByIDAsync(4);
                    Assert.Null(result);
                }
            }
        }
        [Fact]
        public async void UpdateCommentAsyncShouldUpdateComment()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                Comments testComment = new Comments();
                testComment.Id = 4;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var newComment = await _repo.AddCommentAsync(testComment);
                Assert.Equal("First Comment", newComment.Comment);
                testComment.Comment = "Edit: I was actually second.";
                var updatedComment = await _repo.UpdateCommentAsync(testComment);
                Assert.Equal("Edit: I was actually second.", updatedComment.Comment);
            }
        }
       #endregion
        // MusicPlaylist
        #region
        [Fact]
        public async void GetMusicPlaylistsAsyncShouldReturnAllMusicPlaylists()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);

                var musicPlaylists = await _repo.GetMusicPlaylistsAsync();
                Assert.Equal(3, musicPlaylists.Count);
            }
        }
        [Fact]
        public async void GetMusicPlaylistByIDAsyncShouldReturnMusicPlaylist()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                var foundMusicPlaylist = await _repo.GetMusicPlaylistByIDAsync(4);
                Assert.NotNull(foundMusicPlaylist);
                Assert.Equal(4, foundMusicPlaylist.Id);
            }
        }
        [Fact]
        public async void AddMusicPlaylistAsyncShouldAddMusicPlaylist()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                Assert.NotNull(newMusicPlaylist);
                Assert.Equal(2, newMusicPlaylist.PlayListId);
            }
        }
        [Fact]
        public async void DeleteMusicPlaylistAsyncShouldDeleteMusicPlaylist()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                var deleteMusicPlaylist = await _repo.DeleteMusicPlaylistAsync(testMusicPlaylist);
                using (var assertContext = new MusicDBContext(options))
                {
                    var result = assertContext.MusicPlaylist.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdateMusicPlaylistAsyncShouldUpdateMusicPlaylist()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                testMusicPlaylist.PlayListId = 1;
                var updateMusicPlaylist = await _repo.UpdateMusicPlaylistAsync(testMusicPlaylist);
                Assert.Equal(1, updateMusicPlaylist.PlayListId);
            }
        }
        #endregion
         // UploadMusic
        [Fact]
        public async void GetUploadedMusicAsyncShouldReturnAllUploadedMusic()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);

                var uploadedMusic = await _repo.GetUploadedMusicAsync();
                Assert.Equal(2, uploadedMusic.Count);
            }
        }
        [Fact]
        public async void GetUploadedMusicByIDAsyncShouldReturnUploadedMusic()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                var foundUploadedMusic = await _repo.GetUploadedMusicByIDAsync(4);
                Assert.NotNull(foundUploadedMusic);
                Assert.Equal(4, foundUploadedMusic.Id);
            }
        }
        [Fact]
        public async void GetUploadedMusicByUserIDAsyncShouldReturnUploadedMusic()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                var foundUploadedMusic = await _repo.GetUploadedMusicByUserIDAsync(1);
                Assert.NotNull(foundUploadedMusic);
                Assert.Equal(1, testUploadMusic.UserId);
            }
        }
        [Fact]
        public async void AddUploadedMusicAsyncShouldAddUploadedMusic()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                Assert.Equal("Jumping Jacks", newUploadMusic.Name);
            }
        }
        [Fact]
        public async void DeleteUploadedMusicAsyncShouldDeleteUploadedMusic()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                var deletedUploadMusic = await _repo.DeleteUploadedMusicAsync(testUploadMusic);
                using (var assertContext = new MusicDBContext(options))
                {
                    var result = assertContext.UploadMusic.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdateUploadedMusicAsyncShouldUpdateUploadedMusic()
        {
            using (var context = new MusicDBContext(options))
            {
                IMusicRepoDB _repo = new MusicRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                testUploadMusic.Name = "Jumping Jax";
                var updateUploadMusic = await _repo.UpdateUploadedMusicAsync(testUploadMusic);
                Assert.Equal("Jumping Jax", updateUploadMusic.Name);
            }
        }
        //Seed
        #region
        private void Seed()
        {
            using (var context = new MusicDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.PlayList.AddRange(
                    new PlayList
                    {
                        Id = 1,
                        UserId = 1,
                        Name = "Sick EDM"
                    },
                    new PlayList
                    {
                        Id = 2,
                        UserId = 2,
                        Name = "Country"
                    }

                    );

                context.UploadMusic.AddRange(
                    new UploadMusic
                    {
                        Id = 1,
                        UserId = 1,
                        MusicFilePath = "cool_song",
                        Name = "Jumping Jacks",
                        UploadDate = DateTime.Parse("2021-03-15 18:17:00"),
                        Likes = 3409,
                        Plays = 90845


                    },
                    new UploadMusic
                    {
                        Id = 2,
                        UserId = 2,
                        MusicFilePath = "crazy_mix",
                        Name = "BBCRadio1Xtra Mix - Jack",
                        UploadDate = DateTime.Parse("2021-03-16 18:18:00"),
                        Likes = 8709,
                        Plays = 3937829
                    }

                    );

                context.Comments.AddRange(
                    new Comments
                    {
                        Id = 1,
                        Comment = "wow this song is so sick what the heck!",
                        CommentData = DateTime.Parse("2021-03-15 18:17:00"),
                        UserId = 2,
                        UploadMusicId = 1
                    },
                    new Comments
                    {
                        Id = 2,
                        Comment = "what.. this song transition... amazing!",
                        CommentData = DateTime.Parse("2021-03-15 18:17:00"),
                        UserId = 1,
                        UploadMusicId = 2
                    }

                    );
                context.MusicPlaylist.AddRange(
                    new MusicPlaylist
                    {
                        Id = 1,
                        PlayListId = 1,
                        MusicId = 1,
                    },
                    new MusicPlaylist
                    {
                        Id = 2,
                        PlayListId = 1,
                        MusicId = 2
                    },
                    new MusicPlaylist
                    {
                        Id = 3,
                        PlayListId = 2,
                        MusicId = 1
                    }

                    );
                context.SaveChanges();
            }
        }
        #endregion
        

    }

}