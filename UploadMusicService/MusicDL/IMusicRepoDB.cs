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

        Task<PlayList> AddPlayListAsync(PlayList newPlaylist);
        Task<PlayList> DeletePlayListAsync(PlayList playlist2BDeleted);
        Task<PlayList> GetPlayListByIDAsync(int id);
        Task<List<PlayList>> GetPlayListsAsync();
        Task<PlayList> UpdatePlayListAsync(PlayList playlist2BUpdated);

        Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist);
        Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted);
        Task<MusicPlaylist> GetMusicPlaylistByIDAsync(int id);
        Task<List<MusicPlaylist>> GetMusicPlaylistsAsync();
        Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated);

        Task<Comments> AddCommentAsync(Comments newComment);
        Task<Comments> DeleteCommentAsync(Comments comment2BDeleted);
        Task<Comments> GetCommentByIDAsync(int id);
        Task<List<Comments>> GetCommentsAsync();
        Task<Comments> UpdateCommentAsync(Comments comment2BUpdated);
        Task<List<Comments>> GetCommentsByMusicIDAsync(int id);
    }
}