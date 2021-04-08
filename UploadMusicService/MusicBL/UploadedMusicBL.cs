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

        // Adding a new playlist
        public async Task<PlayList> AddPlayListAsync(PlayList newPlayList)
        {
            PlayList playList2Add = new PlayList();
            playList2Add.Id = newPlayList.Id;
            playList2Add.Name = newPlayList.Name;
            playList2Add.UserId = newPlayList.UserId;
            return await _repo.AddPlayListAsync(playList2Add);
        }

        // Deleting a playlist
        public async Task<PlayList> DeletePlayListAsync(PlayList playlist2BDeleted)
        {
            return await _repo.DeletePlayListAsync(playlist2BDeleted);
        }

        // Retrieving a playlist by ID
        public async Task<PlayList> GetPlayListByIDAsync(int id)
        {
            return await _repo.GetPlayListByIDAsync(id);
        }

        // Retrieving playlists
        public async Task<List<PlayList>> GetPlayListsAsync()
        {
            return await _repo.GetPlayListsAsync();
        }

        // Updating a playlist
        public async Task<PlayList> UpdatePlayListAsync(PlayList playlist2BUpdated)
        {
            return await _repo.UpdatePlayListAsync(playlist2BUpdated);
        }

        // Adding a new music playlist
        public async Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist)
        {
            return await _repo.AddMusicPlaylistAsync(newMusicPlaylist);
        }

        // Deleting a music playlist
        public async Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted)
        {
            return await _repo.DeleteMusicPlaylistAsync(musicPlaylist2BDeleted);
        }

        // Retrieving a music playlist by id
        public async Task<MusicPlaylist> GetMusicPlaylistByIDAsync(int id)
        {
            return await _repo.GetMusicPlaylistByIDAsync(id);
        }

        // Retrieving music playlists
        public async Task<List<MusicPlaylist>> GetMusicPlaylistsAsync()
        {
            return await _repo.GetMusicPlaylistsAsync();
        }

        // Updating a music playlist
        public async Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated)
        {
            return await _repo.UpdateMusicPlaylistAsync(musicPlaylist2BUpdated);
        }

        // Adding a new comment
        public async Task<Comments> AddCommentAsync(Comments newComment)
        {
            Comments comment2Add = new Comments();
            comment2Add.Comment = newComment.Comment;
            comment2Add.CommentData = DateTime.Now;
            comment2Add.Id = 0;
            comment2Add.UploadMusicId = newComment.UploadMusicId;
            comment2Add.UserId = newComment.UserId;
            return await _repo.AddCommentAsync(comment2Add);
        }

        // Deleting a comment
        public async Task<Comments> DeleteCommentAsync(Comments comment2BDeleted)
        {
            return await _repo.DeleteCommentAsync(comment2BDeleted);
        }

        // Retrieving a comment by id
        public async Task<Comments> GetCommentByIDAsync(int id)
        { 
            return await _repo.GetCommentByIDAsync(id);
        }

        // Retrieving comments
        public async Task<List<Comments>> GetCommentsAsync()
        {
            return await _repo.GetCommentsAsync();
        }

        // Updating a comment
        public async Task<Comments> UpdateCommentAsync(Comments comment2BUpdated)
        {
            return await _repo.UpdateCommentAsync(comment2BUpdated);
        }

        // Retrieving a comment by Music id
        public async Task<List<Comments>> GetCommentsByMusicIDAsync(int id)
        {
            return await _repo.GetCommentsByMusicIDAsync(id);
        }
    }
}
