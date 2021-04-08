using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicModels;

namespace MusicBL
{
    public interface IUploadMusicBL
    {
        Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic);
        Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted);
        Task<List<UploadMusic>> GetUploadedMusicAsync();
        Task<UploadMusic> GetUploadedMusicByIDAsync(int id);
        Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid);
        Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated);

        Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist);
        Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted);
        Task<MusicPlaylist> GetMusicPlaylistByIDAsync(int id);
        Task<List<MusicPlaylist>> GetMusicPlaylistsAsync();
        Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated);
    }
}
