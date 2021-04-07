using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MixerModels
{
    public class UploadMusic
    {
        private int userId;
        private string musicFilePath;
        private string name;
        private DateTime uploadDate;
        private int likes;
        private int plays;
        private bool isPrivate;
        private bool isApproved;
        private bool isLocked;
        private ICollection<MusicPlaylist> musicPlaylists;
        private ICollection<Comments> comments;
        private UriParser user;

        public int Id { get; set; }
        public int UserId { get; set; }
        public string MusicFilePath { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public int Likes { get; set; }
        public int Plays { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLocked { get; set; }

        public ICollection<MusicPlaylist> MusicPlaylists { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public User User { get; set; }
    }
}