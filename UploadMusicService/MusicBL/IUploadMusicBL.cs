﻿using System;
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

        Task<PlayList> AddPlayListAsync(PlayList newPlaylist);
        Task<PlayList> DeletePlayListAsync(PlayList playlist2BDeleted);
        Task<PlayList> GetPlayListByIDAsync(int id);
        Task<List<PlayList>> GetPlayListsAsync();
        Task<PlayList> UpdatePlayListAsync(PlayList playlist2BUpdated);
    }
}
