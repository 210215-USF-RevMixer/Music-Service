﻿using MusicModels;
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
    public class UploadMusicRepoDB : IMusicRepoDB
    {
        private readonly UploadMusicDBContext _context;

        public UploadMusicRepoDB(UploadMusicDBContext context)
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
            return await _context.UploadMusic.ToListAsync();
        }

        // Get a Uploaded music object by Id
        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            return await _context.UploadMusic
                .Where(um => um.Id == id)
                .FirstOrDefaultAsync();
        }

        // Get Uploaded music by user Id
        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            return await _context.UploadMusic
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
    }
}
