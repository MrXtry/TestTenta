using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TestTenta.ViewModels;
using TestTenta.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTenta.Controllers
{
    public class ArtistsController : Controller
    {
        IArtistRepository artistRepository;
        public ArtistsController(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(artistRepository.GetAllArtists());
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditArtistViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            artistRepository.EditArtist(viewModel);

            return RedirectToAction("index");
        }

        public IActionResult PartialView(int id)
        {
            var artist = artistRepository.GetArtistDescription(id);

            return PartialView("_ArtistBox", artist);
        }
    }
}
