using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models;

public sealed class PersonModel
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string? FirstName { get; set; }

    [Required, MaxLength(50)]
    public string? LastName { get; set; }
}
