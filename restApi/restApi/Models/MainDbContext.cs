using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restApi.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusiciansTracks { get; set; }
        public DbSet<MusicLabel> MusicsLabels { get; set; }
        public DbSet<Track> Tracks{ get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MusicLabel>(ml =>
            {
                ml.HasKey(e => e.IdMusicLabel);
                ml.Property(e => e.Name).HasMaxLength(50).IsRequired();
                ml.HasData(new MusicLabel { IdMusicLabel = 1, Name = "SBM" });
                ml.HasData(new MusicLabel { IdMusicLabel = 2, Name = "QQ" });
            });

            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                a.Property(e => e.PublishDate).IsRequired();
                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel).OnDelete(DeleteBehavior.Restrict);

                a.HasData(
                    new Album { IdAlbum = 1, AlbumName = "costam", PublishDate = DateTime.Parse("2022-02-01"), IdMusicLabel = 1 },
                    new Album { IdAlbum = 2, AlbumName = "costamdwa", PublishDate = DateTime.Parse("2022-02-02"), IdMusicLabel = 2 });
            });
            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                m.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                m.Property(e => e.NickName).HasMaxLength(20);

                m.HasData(
                    new Musician { IdMusician = 1, FirstName = "Filip", LastName = "Wozniak", NickName = "filip123" },
                    new Musician { IdMusician = 2, FirstName = "Patrycja", LastName = "Filipo", NickName = "patrycja123" });
                
            });
            modelBuilder.Entity<MusicianTrack>(mt =>
            {
                mt.HasKey(e => new
                {
                    e.IdMusician,
                    e.IdTrack
                });
                mt.HasOne(e => e.Track).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.Restrict);
                mt.HasOne(e => e.Musician).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdMusician).OnDelete(DeleteBehavior.Restrict);

                mt.HasData(
                    new MusicianTrack { IdTrack = 1, IdMusician = 1});

            });
          
            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                t.Property(e => e.Duration).IsRequired();
                t.HasOne(e => e.album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum).OnDelete(DeleteBehavior.Restrict);
                t.HasData(new Track { IdTrack = 1, TrackName = "kawalek", Duration = 3, IdMusicAlbum = 1 });
            });
            


        }

        
    }
}
