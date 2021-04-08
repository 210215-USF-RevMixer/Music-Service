using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicModels
{
    public class Comments
    {
        private string comment;
        private DateTime commentData;
        private int userId;
        private int uploadMusicId;
        private UploadMusic uploadedMusic;
        public int Id { get; set; }

        public string Comment { 
            get { return comment; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                comment = value;
            }
        }
        public DateTime CommentData
        {
            get { return commentData; }
            set
            {
                if (value.GetType() != typeof(DateTime))
                {
                    throw new ArgumentException("value");
                }
                commentData = value;
            }
        }
        public int UserId
        {
            get { return userId; }
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                userId = value;
            }
        } //fk

        public int UploadMusicId
        {
            get { return uploadMusicId; }
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                uploadMusicId = value;
            }
        } //fk

        public UploadMusic UploadedMusic
        {
            get { return uploadedMusic; }
            set
            {
                if (value.GetType() != typeof(UploadMusic))
                {
                    throw new ArgumentException("value");
                }
                uploadedMusic = value;
            }
        }
    }
}
