using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities;

public class ApplicationUser
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public string Email { get; set; } 

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } 

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(512)]
    public string PasswordHash { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}