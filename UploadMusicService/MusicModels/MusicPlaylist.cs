using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicModels
{
    public class MusicPlaylist
    {
        private int playListId;
        private PlayList playList;
        private UploadMusic uploadMusic;
        private int musicId;
        public int Id { get; set; }
        public int PlayListId { get; set; }

        public PlayList PlayList { get; set; }

        public UploadMusic UploadMusic { get; set; }

        public int MusicId { get; set; }
    }
}
