using MusicModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace MusicDL
{
    /// <summary>
    /// This class as a whole has all the necessary functionality for uploaded music, music playlist, playlist, and comment objects to our database with all the basic CRUD operations 
    /// with some special cases for the reading/get methods.
    /// </summary>
    public class MusicRepoDB : IMusicRepoDB
    {
        private readonly MusicDBContext _context;

        public MusicRepoDB(MusicDBContext context)
        {
            _context = context;
        }

        // Adding a Upload music object to the database
        public async Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            await _context.UploadMusic.AddAsync(newUploadedMusic);
            await _context.SaveChangesAsync();
            return newUploadedMusic;
        }

        // Deleting a Upload music object from the database
        public async Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            _context.UploadMusic.Remove(uploadedMusic2BDeleted);
            await _context.SaveChangesAsync();
            return uploadedMusic2BDeleted;
        }

        // Getting all Uploaded music from database
        public async Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            return await _context.UploadMusic
                .Include(um => um.Comments)
                .ToListAsync();
        }

        // Get a Uploaded music object by Id
        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            return await _context.UploadMusic
                .Include(um => um.Comments)
                .Where(um => um.Id == id)
                .FirstOrDefaultAsync();
        }

        // Get Uploaded music by user Id
        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            return await _context.UploadMusic
                .Include(um => um.Comments)
                .Where(um => um.UserId == userid)
                .ToListAsync();
        }

        // Updating a uploaded music object by getting the old object, setting its information with the new object passed into it, and then saving it to the database
        public async Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            UploadMusic oldUploadedMusic = await _context.UploadMusic.Where(um => um.Id == uploadedMusic2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldUploadedMusic).CurrentValues.SetValues(uploadedMusic2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return uploadedMusic2BUpdated;
        }

        // Adding a playlist object to the database
        public async Task<PlayList> AddPlayListAsync(PlayList newPlayList)
        {
            await _context.PlayList.AddAsync(newPlayList);
            await _context.SaveChangesAsync();
            return newPlayList;
        }

        // Deleting a playlist from the database 
        public async Task<PlayList> DeletePlayListAsync(PlayList playList2BDeleted)
        {
            _context.PlayList.Remove(playList2BDeleted);
            await _context.SaveChangesAsync();
            return playList2BDeleted;
        }

        // Get playlist by id
        public async Task<PlayList> GetPlayListByIDAsync(int id)
        {
            return await _context.PlayList
                .Include(p => p.MusicPlaylist)
                .ThenInclude(mp => mp.UploadMusic)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        // Get all playlists
        public async Task<List<PlayList>> GetPlayListsAsync()
        {
            return await _context.PlayList
                .Include(p => p.MusicPlaylist)
                .ThenInclude(mp => mp.UploadMusic)
                .ToListAsync();
        }

        // Updating a playlist object by getting the old object, setting its information with the new object passed into it, and then saving it to the database
        public async Task<PlayList> UpdatePlayListAsync(PlayList playList2BUpdated)
        {
            PlayList oldPlaylist =
                await _context.PlayList.Where(p => p.Id == playList2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldPlaylist).CurrentValues.SetValues(playList2BUpdated);
            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return playList2BUpdated;
        }

        // Adding a music playlist object to the database
        public async Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist)
        {
            await _context.MusicPlaylist.AddAsync(newMusicPlaylist);
            await _context.SaveChangesAsync();
            return newMusicPlaylist;
        }

        // Deleting a music playlist object to the database
        public async Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted)
        {
            _context.MusicPlaylist.Remove(musicPlaylist2BDeleted);
            await _context.SaveChangesAsync();
            return musicPlaylist2BDeleted;
        }

        // Get a music playlist object by Id
        public async Task<MusicPlaylist> GetMusicPlaylistByIDAsync(int id)
        {
            return await _context.MusicPlaylist
                .Include(mp => mp.UploadMusic)
                .Include(mp => mp.PlayList)
                .Where(mp => mp.Id == id)
                .FirstOrDefaultAsync();
        }

        // Getting all music playlists from database
        public async Task<List<MusicPlaylist>> GetMusicPlaylistsAsync()
        {
            return await _context.MusicPlaylist
                .Include(mp => mp.UploadMusic)
                .Include(mp => mp.PlayList)
                .ToListAsync();
        }

        // Updating a music playlist object by getting the old object, setting its information with the new object passed into it, and then saving it to the database
        public async Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated)
        {
            MusicPlaylist oldMusicPlaylist = await _context.MusicPlaylist.Where(mp => mp.Id == musicPlaylist2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldMusicPlaylist).CurrentValues.SetValues(musicPlaylist2BUpdated);


            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return musicPlaylist2BUpdated;
        }

        // Adding a comment object to the database
        public async Task<Comments> AddCommentAsync(Comments newComment)
        {
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return newComment;
        }

        // Deleting a comment object from the database
        public async Task<Comments> DeleteCommentAsync(Comments comment2BDeleted)
        {
            _context.Comments.Remove(comment2BDeleted);
            await _context.SaveChangesAsync();
            return comment2BDeleted;
        }

        // Get a music playlist object by Id
        public async Task<Comments> GetCommentByIDAsync(int id)
        {
            return await _context.Comments
                .Include(c => c.UploadedMusic)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        // Getting all comments from database
        public async Task<List<Comments>> GetCommentsAsync()
        {
            return await _context.Comments
                .Include(c => c.UploadedMusic)
                .AsNoTracking()
                .ToListAsync();
        }

        // Updating a comment object by getting the old object, setting its information with the new object passed into it, and then saving it to the database
        public async Task<Comments> UpdateCommentAsync(Comments comment2BUpdated)
        {
            Comments oldComment = await _context.Comments.Where(c => c.Id == comment2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldComment).CurrentValues.SetValues(comment2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return comment2BUpdated;
        }

        // Get a music playlist object by music id
        public async Task<List<Comments>> GetCommentsByMusicIDAsync(int id)
        {
            return await _context.Comments
                .AsNoTracking()
                .Where(c => c.UserId == id)
                .ToListAsync();
        }
    }
}
