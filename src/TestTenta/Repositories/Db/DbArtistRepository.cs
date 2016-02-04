using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTenta.Models;
using TestTenta.ViewModels;

namespace TestTenta.Repositories.Db
{
    public class DbArtistRepository : IArtistRepository
    {
        private readonly DataContext context;

        public DbArtistRepository(DataContext context)
        {
            this.context = context;
        }

        public ArtistBoxViewModel GetArtistDescription(int id)
        {
            var artist = context
                .Artists
                .Where(a => a.Id == id)
                .Select(a => new ArtistBoxViewModel
                {
                    Id = a.Id,
                    Description = a.Description
                })
                .SingleOrDefault();

            return artist;
        }

        public void EditArtist(EditArtistViewModel model)
        {
            var artist = new Artist
            {
                Id = model.Id,
                Name = model.Name,
                EMail = model.Email,
                Revenue = model.Revenue,
                Description = model.Description
            };

            context.Artists.Update(artist);
            context.SaveChanges();
        }

        public ListArtistsViewModel[] GetAllArtists()
        {
            return context
                .Artists
                .Select(a => new ListArtistsViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Revenue = a.Revenue
                    
                })
                .ToArray();
        }
    }
}
