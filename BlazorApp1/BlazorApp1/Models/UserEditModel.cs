using BlazorApp1.Data;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BlazorApp1.Models
{
    public sealed class UserEditModel
    {
        public UserEditModel()
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

        [Display(Name = "Name")]
        public string Name { get; set; } = "";

        [Display(Name = "Surname")]
        public string Surname { get; set; } = "";

        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; } = "";

        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }

    }
}