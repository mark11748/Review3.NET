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
        public string Author { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
