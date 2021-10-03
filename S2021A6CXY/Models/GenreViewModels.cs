using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6CXY.Models
{
    public class GenreBaseViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}