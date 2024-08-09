using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? Name;
        [Required]
        public string? Surname;
        [Required]
        public string? Patronymic;
        //[Required]
        //public string? StudyGroup;
    }

    public static class Roles
    {
        public static string[] RoleNames = { "Admin", "Student" };
    }
}
