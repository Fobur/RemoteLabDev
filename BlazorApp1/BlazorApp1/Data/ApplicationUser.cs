using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Patronymic { get; set; }
        [Required]
        public StudentGroup StudentGroup { get; set; }
    }

    public static class Roles
    {
        public static string[] RoleNames = { "Admin", "Student" };
    }
}
