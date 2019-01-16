using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //with this attribute the user is not required to enter the time info, only date in displayed
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Range(1, 100)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
// The System.ComponentModel.DataAnnotations class provides a built-in set of validation attributes that can be
// declaratively applied to any class or property.
// It also contains some formatting attributes.

// Some of these attributes:
// Required
// StringLength
// RegularExpression
// Range

// decimal, float, int, DateTime normaly are required and do not need [Required] attribute

// DataType: Date, Time, PhoneNumber, Currency, EmailAddress etc.