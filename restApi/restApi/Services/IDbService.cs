using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restApi.Services
{
    public interface IDbService
    {
        public Task<GetAlbum> GetAlbum(int albumId);

        public Task<bool> CheckIfAlbumExists(int albumId);
        
    }
}
