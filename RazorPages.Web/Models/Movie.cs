using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Release Date")]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
