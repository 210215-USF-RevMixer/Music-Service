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

        public int Id { get; set; }
        public int UserId { 
            get { return userId; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                userId = value;
            }
        }
        public string MusicFilePath {
            get { return musicFilePath; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                musicFilePath = value;
            }
        }
        public string Name {
            get { return name; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                name = value;
            }
        }
        public DateTime UploadDate {
            get { return uploadDate; }
            set
            {
                if (value.GetType() != typeof(DateTime))
                {
                    throw new ArgumentException("value");
                }
                uploadDate = value;
            }
        }
        public int Likes {
            get { return likes; }
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                likes = value;
            }
        }
        public int Plays {
            get { return plays; }
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                plays = value;
            }
        }
        public bool IsPrivate {
            get { return isPrivate; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                isPrivate = value;
            }
        }
        public bool IsApproved {
            get { return isApproved; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                isApproved = value;
            }
        }
        public bool IsLocked {
            get { return isLocked; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                isLocked = value;
            }
        }

    }
}