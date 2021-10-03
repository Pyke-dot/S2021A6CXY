using S2021A6CXY.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6CXY.Models
{
    public class ArtistBaseViewModel
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }
        [Display(Name = "If Applicable, artist's birth name")]
        public string BirthName { get; set; }
        [Display(Name = "Birthday or start date")]
        [DataType(DataType.Date)]
        public DateTime BirthOrStartDate { get; set; }
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }
        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }
        [Display(Name = "Executive who look after this artist")]
        public string Executive { get; set; }
        
    }

    public class ArtistWithDetailViewModel : ArtistBaseViewModel
    {
        public ArtistWithDetailViewModel()
        {
            

        }
        
        [Display(Name = "Artist biography")]
        [StringLength(10000)]
        public string Biography { get; set; }
    }

    public class ArtistAddViewModel
    {

        public ArtistAddViewModel()
        {
            Albums = new List<Album>();
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        public IEnumerable<Album> Albums { get; set; }

        [StringLength(30)]
        public string Genre { get; set; }
        [Display(Name = "Artist name or stage name")]
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "If Applicable, artist's birth name")]
        public string BirthName { get; set; }
        [Display(Name = "Birthday or start date"), DataType(DataType.Date), Required]
        public DateTime BirthOrStartDate { get; set; }
        [Required, Display(Name = "Url to artist photo")]
        public string UrlArtist { get; set; }
        
        public string Executive { get; set; }
        [Display(Name = "Album's primary genre")]
        public SelectList GenreList { get; set; }

        [StringLength(10000)]
        [Display(Name = "Artist biography")]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }
    }

    public class ArtistAddFormViewModel : ArtistAddViewModel
    {

    }

    public class ArtistWithMediaItemViewModel : ArtistWithDetailViewModel
    {
        public ArtistWithMediaItemViewModel()
        {
            ArtistMediaItems = new List<ArtistMediaItem>();
        }
        
        public IEnumerable<ArtistMediaItem> ArtistMediaItems { get; set; }
    }
}