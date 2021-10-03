using S2021A6CXY.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6CXY.Models
{
    public class AlbumBaseViewModel
    {
        public AlbumBaseViewModel()
        {

        }
        [Display(Name = "Album name")]
        public string Name { get; set; }
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Album Image(cover art)")]
        public string UrlAlbum { get; set; }
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }
        [Display(Name = "Coordinator who looks after this album")]
        public string Coordinator { get; set; }
        [Required]
        public int Id { get; set; }


    }
    public class AlbumWithDetailViewModel : AlbumBaseViewModel
    {
        [Display(Name = "Album summary")]
        [StringLength(10000)]
        public string Summary { get; set; }

    }

    public class AlbumAddViewModel 
    {
        public AlbumAddViewModel()
        {
            Artists = new List<Artist>();
            Tracks = new List<Track>();
            ReleaseDate = DateTime.Now;

        }
        [Display(Name = "Album's primary genre")]
        public SelectList GenreList { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Album name"), Required]
        public string Name { get; set; }

        [Display(Name = "Release date"), DataType(DataType.Date), Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Url to album image (cover art)"), Required]
        public string UrlAlbum { get; set; }

        [StringLength(10000)]
        [Display(Name = "Album summary")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        public string ArtistName { get; set; }

        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
        
        public int ArtistId { get; set; }

    }

    public class AlbumAddFormViewModel : AlbumAddViewModel
    {
        public AlbumAddFormViewModel()
        {
            
        }

        
        

    }
}