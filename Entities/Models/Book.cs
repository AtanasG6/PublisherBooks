using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Book
{
    [Column("BookId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Book title is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Title is 100 characters.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Page count is a required field.")]
    public int PageCount { get; set; }

    [Required(ErrorMessage = "Genre is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Genre is 30 characters.")]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "Release year is a required field.")]
    public int ReleaseYear { get; set; }

    [ForeignKey(nameof(Publisher))]
    public Guid PublisherId { get; set; }

    public Publisher? Publisher { get; set; }
}
