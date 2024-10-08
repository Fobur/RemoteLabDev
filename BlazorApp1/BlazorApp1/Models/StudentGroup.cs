﻿using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class StudentGroup
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
