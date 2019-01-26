using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name="Number in Stock")]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }    // Navigation Property

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }   // foreign key;  validate this field not the Navigation Prop.

        public byte NumberAvailable { get; set; }
    }
}