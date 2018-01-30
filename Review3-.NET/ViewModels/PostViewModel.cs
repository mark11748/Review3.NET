using System;
using System.ComponentModel.DataAnnotations;
using Review3_.NET.Models;

namespace Review3_.NET.ViewModels
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Message Body")]
        public string Body { get; set; }
        [Required]
        public User user { get; set; }
    }
}
