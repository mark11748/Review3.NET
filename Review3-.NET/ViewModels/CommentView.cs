using System;
using System.ComponentModel.DataAnnotations;
using Review3_.NET.Models;

namespace Review3_.NET.ViewModels
{
    public class CommentViewModel
    {
        public User User { get; set; }
        public string Body { get; set; }
        public Post post { get; set; }
    }
}
