using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6CXY.Controllers
{
    public class ClipController : Controller
    {   
        private Manager m = new Manager();
        // GET: Clip
        public ActionResult Index()
        {
            return View();
        }
        [Route("clip/{id}")]
        public ActionResult Details(int? id)
        {
            var a = m.TrackClipGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {

                if (a.ClipContentType != null)
                {
                    return File(a.Clip, a.ClipContentType);
                } 

                return Content("No audio");
            }

        }
    }
}