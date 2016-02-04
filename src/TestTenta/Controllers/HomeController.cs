using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TestTenta.Repositories;
using TestTenta.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTenta.Controllers
{
    public class HomeController : Controller
    {
        IArtistRepository artistRepository;
        public HomeController(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(artistRepository.GetAllArtists());
        }

        public IActionResult PartialView(int id)
        {
            var artist = artistRepository.GetArtistDescription(id);

            return PartialView("_ArtistBox", artist);
        }
    }
}
