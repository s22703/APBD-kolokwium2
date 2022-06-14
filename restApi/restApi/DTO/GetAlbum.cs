using System;
using System.Collections.Generic;

namespace restApi.Services
{
    public class GetAlbum
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<TrackGet> AlbumTracks { get; set; }

    }
}