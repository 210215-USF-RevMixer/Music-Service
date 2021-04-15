using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MusicDL;
using MusicModels;

namespace MixerTests
{
    public class MusicServiceDLTests
    {
        private readonly DbContextOptions<MusicDBContext> options;
        public MusicServiceDLTests()
        {
            options = new DbContextOptionsBuilder<MusicDBContext>()
          .UseSqlite("Filename=Test.db")
          .Options;
            Seed();
        }

        [Fact]
        public async Task GetPlayListsAsync_ShouldReturnPlaylistObjects()
        {
            using (var context = new MusicDBContext(options))
            {
            
                IMusicRepoDB _repo = new MusicRepoDB(context);
                var  playlist = await _repo.GetPlayListsAsync();
                Assert.True(playlist is List<PlayList>);
            }
        }

        [Fact]
        public async Task GetPlayListsBIDAsync_ShouldReturnPlaylistObject()
        {
            using (var context = new MusicDBContext(options))
            {

                IMusicRepoDB _repo = new MusicRepoDB(context);
                var playlist = await _repo.GetPlayListByIDAsync(1);
                Assert.True(playlist is PlayList);
                Assert.Equal("muffins", playlist.Name);
            }
        }


        [Fact]
        public async Task AddPlayListAsync_ShouldReturnPlaylistObject()
        {
            using (var context = new MusicDBContext(options))
            {
                List<MusicPlaylist> mp = new List<MusicPlaylist>();

                PlayList testp = new PlayList { Name = "scruffins", Id = 2, UserId = 2, MusicPlaylist = mp };

                IMusicRepoDB _repo = new MusicRepoDB(context);
                var playlist = await _repo.AddPlayListAsync(testp);
                Assert.True(playlist is PlayList);
                Assert.Equal("scruffins", playlist.Name);
            }
        }
        [Fact]
        public async Task DeletePlayListAsync_ShouldReturnPlaylistObject()
        {
            using (var context = new MusicDBContext(options))
            {
                List<MusicPlaylist> mp = new List<MusicPlaylist>();
                MusicPlaylist mc = new MusicPlaylist { Id = 1, PlayListId = 1, PlayList = { }, UploadMusic = { }, MusicId = 1 };
                PlayList testp = new PlayList { Name = "muffins", Id = 1, UserId = 1, MusicPlaylist = mp };

                IMusicRepoDB _repo = new MusicRepoDB(context);
                var playlist = await _repo.DeletePlayListAsync(testp);
                Assert.True(playlist is PlayList);
                Assert.Equal("muffins", playlist.Name);
                Assert.True(context.PlayList.Count()==0);
            }
        }



        [Fact]
        public async Task UpdatePlayListAsync_ShouldReturnPlaylistObject()
        {
            using (var context = new MusicDBContext(options))
            {
                List<MusicPlaylist> mp = new List<MusicPlaylist>();
                MusicPlaylist mc = new MusicPlaylist { Id = 1, PlayListId = 1, PlayList = { }, UploadMusic = { }, MusicId = 1 };
                PlayList testp = new PlayList { Name = "puffin", Id = 1, UserId = 1, MusicPlaylist = mp };

                IMusicRepoDB _repo = new MusicRepoDB(context);
                var playlist = await _repo.UpdatePlayListAsync(testp);
                Assert.True(playlist is PlayList);
                Assert.Equal("puffin", playlist.Name);
              
            }
        }
        //      GetPlayListsAsync N/A returns list of PlayList objects    returns list of PlayList objects
        //GetPlaylistByIDAsync    ID Int  returns single PlayList object returns single PlayList object
        //AddPlaylistAsync    PlayList object returns PlayList object Adds a new PlayList object
        //DeletePlayListAsync ID Int  returns PlayList object returns PlayList object
        //UpdatePlayListAsync PlayList object returns PlayList object returns PlayList object


        private void Seed()
        {

            MusicPlaylist mc = new MusicPlaylist { Id = 1, PlayListId = 1, PlayList = { }, UploadMusic = { }, MusicId = 1 };
            List<MusicPlaylist> mp = new List<MusicPlaylist>();
            mp.Add(mc);
            using (var context = new MusicDBContext(options))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

      
       
               
                //private MusicPlaylist;
                context.PlayList.AddRange(new PlayList {Name="muffins",Id=1,UserId=1,MusicPlaylist= mp});
     

       
                context.SaveChanges();
            }

        }
    }

    }

