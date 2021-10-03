using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace S2021A6CXY.Controllers
{
    public class MediaItemController : Controller
    {
        private Manager m = new Manager();
        // GET: MediaItem
        public ActionResult Index()
        {
            return RedirectToAction("index", "home");
        }

        [Route("media/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            var media = m.MediaGetById(stringId);

            if (media == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (media.ContentType != null)
                {
                    return File(media.Content, media.ContentType);
                }

                return Content("No media");
            }
        }
        [Route("media/{stringId}/download")]
        public ActionResult DetailsDownload(string stringId = "")
        {
            // Attempt to get the matching object
            var media = m.MediaGetById(stringId);

            // Working variables
            if (media == null)
            {
                return HttpNotFound();
            }
            else
            {
                RegistryKey key;
                object value;
                string extension;

                // Open the Registry, attempt to locate the key
                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + media.ContentType, false);
                value = (key == null) ? null : key.GetValue("Extension", null);
                extension = (value == null) ? string.Empty : value.ToString();


                // Create a new Content-Disposition header
                var contentDisposition = new System.Net.Mime.ContentDisposition
                {
                    FileName = $"media-{stringId}{extension}",
                    // Force the media item to be saved (not viewed)
                    Inline = false
                }; 

                Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
                return File(media.Content, media.ContentType);
            }
        }
    }
}