using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6CXY.Models
{
    public class ArtistMediaItemBaseViewModel
    {
        public ArtistMediaItemBaseViewModel()
        {
            Timestamp = DateTime.Now;
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            StringId = string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        [Required]
        public string Caption { get; set; }
        
        public string ContentType { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        public string StringId { get; set; }

        public DateTime Timestamp { get; set; }

        
    }
    public class ArtistMediaContentViewModel
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
    public class ArtistMediaItemAddFormViewModel 
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        [Display(Name = "Media item")]
        [DataType(DataType.Upload)]
        [Required]
        public string MediaUpload { get; set; }

        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }
    }
    public class ArtistMediaItemAddViewModel
    {
        public ArtistMediaItemAddViewModel()
        {
            Timestamp = DateTime.Now;
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            StringId = string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        public DateTime Timestamp { get; set; }
        
        public string ContentType { get; set; }
        
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase MediaUpload { get; set; }
        
        [Required]
        public string StringId { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}