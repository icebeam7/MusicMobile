using System;

namespace MusicMobile.Models
{
    public class Song
    {
        public Guid SongID { get; set; }

        public string SongName { get; set; }

        public Guid ArtistID { get; set; }

        public Artist Artist { get; set; }
    }
}
