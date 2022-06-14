using Microsoft.EntityFrameworkCore;
using restApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restApi.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService (MainDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfAlbumExists(int albumId)
        {
            return await _context.Albums.Where(e => e.IdAlbum == albumId).AnyAsync();
        }

        public async Task<GetAlbum> GetAlbum(int albumId)
        {
            
            var track = await _context.Tracks.Where(e => e.IdMusicAlbum == albumId).Select(e => e.IdMusicAlbum).FirstOrDefaultAsync();
            var album = await _context.Albums.Where(e => e.IdAlbum == albumId && e.IdMusicLabel == track).FirstOrDefaultAsync();

            return new GetAlbum
            {
                IdAlbum = album.IdAlbum,
                AlbumName = album.AlbumName,
                PublishDate = album.PublishDate,
                
            };
            





        }
        
    }
}
