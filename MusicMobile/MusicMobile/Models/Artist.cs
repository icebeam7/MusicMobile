using System;
using System.Collections.Generic;

namespace MusicMobile.Models
{
    public class Artist
    {
        public Guid ArtistID { get; set; }

        public string ArtistName { get; set; }

        public List<Song> Songs { get; set; }
    }
}
