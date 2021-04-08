using System.Threading.Tasks;
using System.Collections.Generic;
using MusicModels;

namespace MusicDL
{
    public interface IMusicRepoDB
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