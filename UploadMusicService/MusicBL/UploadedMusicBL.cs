using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicDL;
using MusicModels;

namespace MusicBL
{
    public class UploadedMusicBL : IUploadMusicBL
    {
        // Referencing UploadMusicDL
        private IMusicRepoDB _repo;
        public UploadedMusicBL(IMusicRepoDB repo)
        {
            _repo = repo;
        }

        // Adding a new song
        public async Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            // creating a new UploadMusic object to add to the database
            UploadMusic uploadMusic2Add = new UploadMusic();
            uploadMusic2Add.Id = newUploadedMusic.Id;
            uploadMusic2Add.MusicFilePath = newUploadedMusic.MusicFilePath;
            uploadMusic2Add.Name = newUploadedMusic.Name;
            uploadMusic2Add.UploadDate = DateTime.Now;
            uploadMusic2Add.UserId = newUploadedMusic.UserId;
            uploadMusic2Add.IsPrivate = newUploadedMusic.IsPrivate;
            uploadMusic2Add.IsApproved = newUploadedMusic.IsApproved;
            uploadMusic2Add.IsLocked = newUploadedMusic.IsPrivate;
            return await _repo.AddUploadedMusicAsync(uploadMusic2Add);
        }

        // Deleting a song
        public async Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            return await _repo.DeleteUploadedMusicAsync(uploadedMusic2BDeleted);
        }

        // Retrieving song 
        public async Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            return await _repo.GetUploadedMusicAsync();
        }

        // Retrieving a specific song by id
        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            return await _repo.GetUploadedMusicByIDAsync(id);
        }

        // Retrieving a specific song by User's ID
        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            return await _repo.GetUploadedMusicByUserIDAsync(userid);
        }

        // Updating a song track
        public async Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            return await _repo.UpdateUploadedMusicAsync(uploadedMusic2BUpdated);
        }
    }
}
