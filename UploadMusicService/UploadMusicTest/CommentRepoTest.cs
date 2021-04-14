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
    public class CommentRepoTest
    {
        private readonly DbContextOptions<MusicDBContext> options;
        public CommentRepoTest()
        {
            //use sqlite to create an inmemory test.db
            options = new DbContextOptionsBuilder<MusicDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }
        //Comment
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
       
        private void Seed()
        {
            using (var context = new MusicDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

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
                context.SaveChanges();
            }
        }

    }

}