using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UploadMusicDL;
using UploadMusicModels;

namespace UploadMusicBL
{
    public class UploadMusicBL : IUploadMusicBL
    {
        private IUploadMusicRepoDB _repo;
        public UploadMusicBL(IUploadMusicRepoDB repo)
        {
            _repo = repo;
        }
        public async Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            UploadMusic uploadMusic2Add = new UploadMusic();
            uploadMusic2Add.Id = newUploadedMusic.Id;
            uploadMusic2Add.MusicFilePath = newUploadedMusic.MusicFilePath;
            uploadMusic2Add.Name = newUploadedMusic.Name;
            uploadMusic2Add.UploadDate = DateTime.Now;
            uploadMusic2Add.UserId = newUploadedMusic.UserId;
            uploadMusic2Add.IsPrivate = newUploadedMusic.IsPrivate;
            uploadMusic2Add.IsApproved = newUploadedMusic.IsApproved;
            uploadMusic2Add.IsPrivate = newUploadedMusic.IsPrivate;
            return await _repo.AddUploadedMusicAsync(newUploadedMusic);
        }

        public async Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            return await _repo.DeleteUploadedMusicAsync(uploadedMusic2BDeleted);
        }

        public async Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            return await _repo.GetUploadedMusicAsync();
        }

        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            return await _repo.GetUploadedMusicByIDAsync(id);
        }

        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            return await _repo.GetUploadedMusicByUserIDAsync(userid);
        }

        public async Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            return await _repo.UpdateUploadedMusicAsync(uploadedMusic2BUpdated);
        }
    }
}
