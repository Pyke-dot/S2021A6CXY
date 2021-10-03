using S2021A6CXY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6CXY.Controllers
{
    public class ArtistController : Controller
    {
        private Manager m = new Manager();
        // GET: Artist
        
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artist/Details/5
        
        public ActionResult Details(int? id)
        {
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }

        // GET: Artist/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();


            form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(form);
        }

        // POST: Artist/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newItem);
                }

                // Process the input
                var addedItem = m.ArtistAdd(newItem);

                if (addedItem == null)
                {
                    return View(newItem);
                }
                else
                {
                    return RedirectToAction("details", new { id = addedItem.Id });
                }
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Coordinator")]
        [Route("Artist/AlbumAdd/{id}")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {

                var form = new AlbumAddFormViewModel();


                form.ArtistId = artist.Id;
                form.ArtistName = artist.Name;

                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(form);
            }
        }
        [Route("Artist/AlbumAdd/{id}")]
        [Authorize(Roles = "Coordinator")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel newItem)
        {
            
                if (!ModelState.IsValid)
                {
                    return View(newItem); 
                }

                // Process the input
                var addedItem = m.AlbumAdd(newItem);

                if (addedItem == null)
                {
                    return View(newItem);
                }
                else
                {
                    return RedirectToAction("Details","Album", new { id = addedItem.Id });
                }
            
        }
        [Authorize(Roles = "Executive, Coordinator")]
        public ActionResult AddMedia(int? id)
        {
            var artist = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if(artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new ArtistMediaItemAddFormViewModel();
                form.ArtistId = artist.Id;
                form.ArtistName = artist.Name;
                return View(form);
            }
        }
        [Authorize(Roles = "Executive, Coordinator")]
        [HttpPost]
        public ActionResult AddMedia(int? id, ArtistMediaItemAddViewModel newItem)
        {   

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newItem);
                }

                var addedItem = m.ArtistAddMedia(newItem);

                if (addedItem == null)
                {
                    return View(newItem);
                }
                else
                {
                    return RedirectToAction("Details", "Artist", new { id = addedItem.Id });
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
