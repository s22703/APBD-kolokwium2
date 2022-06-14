﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using restApi.Models;

namespace restApi.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220614111612_dataInserted2")]
    partial class dataInserted2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("restApi.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "costam",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "costamdwa",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("restApi.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicsLabels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "SBM"
                        });
                });

            modelBuilder.Entity("restApi.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Filip",
                            LastName = "Wozniak",
                            NickName = "filip123"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Patrycja",
                            LastName = "Filipo",
                            NickName = "patrycja123"
                        });
                });

            modelBuilder.Entity("restApi.Models.MusicianTrack", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("MusiciansTracks");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        });
                });

            modelBuilder.Entity("restApi.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 3f,
                            IdMusicAlbum = 1,
                            TrackName = "kawalek"
                        });
                });

            modelBuilder.Entity("restApi.Models.Album", b =>
                {
                    b.HasOne("restApi.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("restApi.Models.MusicianTrack", b =>
                {
                    b.HasOne("restApi.Models.Musician", "Musician")
                        .WithMany("MusicianTracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("restApi.Models.Track", "Track")
                        .WithMany("MusicianTracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("restApi.Models.Track", b =>
                {
                    b.HasOne("restApi.Models.Album", "album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("album");
                });

            modelBuilder.Entity("restApi.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("restApi.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("restApi.Models.Musician", b =>
                {
                    b.Navigation("MusicianTracks");
                });

            modelBuilder.Entity("restApi.Models.Track", b =>
                {
                    b.Navigation("MusicianTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
