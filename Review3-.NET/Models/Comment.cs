using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review3_.NET.Models
{
    [Table("Comments")]
    public class Comment
    {
        public Comment(){}
        [Key]
        public int Id { get; set; }
        public User Author { get; set; }
        public string Body { get; private set; }
        public int PostId { get; set; }
    }
}
