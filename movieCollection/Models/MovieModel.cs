using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieCollection.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int movieID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int categoryID { get; set; }

        public Category category { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1900, 2030, ErrorMessage = "Year Must be between 1900 and 2030")]
        public int? year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string director { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lentTo { get; set; }

        [StringLength(25)]
        public string notes { get; set; }

    }
}
