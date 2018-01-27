using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review3_.NET.Models
{
    [Table("Posts")]
    public class Post
    {
        public Post()
        { 
            this.Comments = new HashSet<Comment>(); 
        }
        [Key]
        public int  Id { get; set; }
        public User Author { get; set; }
        public string Body { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
