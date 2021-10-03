using S2021A6CXY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6CXY.Controllers
{
    public class AlbumController : Controller
    {
        private Manager m = new Manager();
        // GET: Album
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());

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

        // GET: Track/Create
        [Authorize(Roles = "Clerk")]
        public ActionResult AddTrack(int? id)
        {
            var album = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());
            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new TrackAddFormViewModel();
                form.AlbumId = album.Id;
                form.AlbumName = album.Name;

                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(form);
            }
        }

        // POST: Track/Create
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult AddTrack(TrackAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {   
                
                return RedirectToAction("Details", "Track", new { id = addedItem.Id });
            }

        }

       
    }
}
