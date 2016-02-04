using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTenta.ViewModels;

namespace TestTenta.Repositories
{
    public interface IArtistRepository
    {
        ListArtistsViewModel[] GetAllArtists();
        void EditArtist(EditArtistViewModel model);
        ArtistBoxViewModel GetArtistDescription(int id);
    }
}
