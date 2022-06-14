namespace restApi.Services
{
    public class TrackGet
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }

        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }

    }
}