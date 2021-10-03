using S2021A6CXY.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6CXY.Models
{
    public class TrackBaseViewModel
    {   
        public TrackBaseViewModel()
        {
            Albums = new List<Album>();
        }
        [Display(Name = "Track name")]
        public string Name { get; set; }
        [Display(Name = "Composer name (comma-separated)")]
        public string Composers { get; set; }
        [Display(Name = "Track Genre")]
        public string Genre { get; set; }

        public string Clerk { get; set; }
        public int Id { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        
    }
    public class TrackAddFormViewModel 
    {
        

        [Display(Name = "Track genre")]
        public SelectList GenreList { get; set; }
        [Display(Name = "Composer name (comma-separated)"), Required]
        public string Composers { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sample Clip")]
        [DataType(DataType.Upload)]
        public string ClipUpload { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        [Display(Name = "Track name"), Required]
        public string Name { get; set; }
    }

    public class TrackAddViewModel 
    {
        public TrackAddViewModel()
        {
            Albums = new List<Album>();
        }
        public int AlbumId { get; set; }

        [Display(Name = "Track name"), Required]
        public string Name { get; set; }
        [Display(Name = "Composer names (comma-seperated)"), Required]
        public string Composers { get; set; }

        public string AlbumName { get; set; }
        [StringLength(30), Required]
        public string Genre { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        
        public HttpPostedFileBase ClipUpload { get; set; }

    }
    public class TrackClipViewModel
    {
        public int id { get; set; }
        public string ClipContentType { get; set; }
        public byte[] Clip { get; set; }
    }

    public class TrackEditViewModel
    {
        public int Id { get; set; }
        public HttpPostedFileBase ClipUpload { get; set; }
    }
    public class TrackEditFormViewModel 
    {   
        public string Name { get; set; }
        [Required]
        [Display(Name = "Sample Clip")]
        [DataType(DataType.Upload)]
        public string ClipUpload { get; set; }
    }
}