using BlazorApp1.Data;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BlazorApp1.Models
{
    public sealed class UserCreationModel
    {
        public UserCreationModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        [Display(Name = "Id")]
         public string Id { get; set; } = "";

         [Required]
         [EmailAddress]
         [Display(Name = "Email")]
         public string Email { get; set; } = "";

         [Required]
         [Display(Name = "Username")]
         public string Username { get; set; } = "";

         [Required]
         [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; } = "";

         [DataType(DataType.Password)]
         [Display(Name = "Confirm password")]
         [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
         public string ConfirmPassword { get; set; } = "";

         [Display(Name = "Name")]
         public string Name { get; set; } = "";

         [Display(Name = "Surname")]
         public string Surname { get; set; } = "";

         [Display(Name = "Patronymic")]
         public string Patronymic { get; set; } = "";

         [Display(Name = "StudentGroup")]
         public StudentGroup StudentGroup { get; set; }


        public List<string> Claims { get; set; }
         public IList<string> Roles { get; set; }
         
    }
}
