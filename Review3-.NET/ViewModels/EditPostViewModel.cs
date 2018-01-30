using System;
using System.ComponentModel.DataAnnotations;
using Review3_.NET.Models;

namespace Review3_.NET.ViewModels
{
    public class EditPostViewModel
    {
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Message Body")]
        public string Body { get; set; }
    }
}
