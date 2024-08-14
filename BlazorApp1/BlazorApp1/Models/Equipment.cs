﻿using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Equipment
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
