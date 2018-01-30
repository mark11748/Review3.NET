using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Review3_.NET.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int  Id { get; set; }
        public string Body { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
