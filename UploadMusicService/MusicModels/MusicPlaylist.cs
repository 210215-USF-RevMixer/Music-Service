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
        public int PlayListId
        {
            get { return playListId; }
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                playListId = value;
            }
        }

        public PlayList PlayList
        {
            get { return playList; }
            set
            {
                if (value.GetType() != typeof(PlayList))
                {
                    throw new ArgumentException("value");
                }
                playList = value;
            }
        }

        public UploadMusic UploadMusic
        {
            get { return uploadMusic; }
            set
            {
                if (value.GetType() != typeof(UploadMusic))
                {
                    throw new ArgumentException("value");
                }
                uploadMusic = value;
            }
        }

        public int MusicId
        {
            get { return musicId; }
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                musicId = value;
            }
        }
    }
}
