using System.Threading.Tasks;
using System.Collections.Generic;
using UploadMusicModels;

namespace UploadMusicDL
{
    interface IUploadMusicRepoDB
    {
        Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic);
        Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted);
        Task<List<UploadMusic>> GetUploadedMusicAsync();
        Task<UploadMusic> GetUploadedMusicByIDAsync(int id);
        Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid);
        Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated);
    }
}