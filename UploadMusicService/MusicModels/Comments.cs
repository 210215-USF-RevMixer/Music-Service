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
        public string Comment { get; set; }
        public DateTime CommentData { get; set; }
        public int UserId { get; set; } //fk

        public int UploadMusicId { get; set; } //fk

        public UploadMusic UploadedMusic { get; set; }
    }
}
