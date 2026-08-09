using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Publisher
{
    [Column("PublisherId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Publisher name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Publisher city is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the City is 60 characters.")]
    public string? City { get; set; }

    public string? Country { get; set; }
}
