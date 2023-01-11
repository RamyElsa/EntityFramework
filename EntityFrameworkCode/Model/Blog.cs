using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCode.Model
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int BlogId { get; set; }
        public DateTime AddedOn { get; set; }
        public string Url { get; set; }

        [InverseProperty(nameof(Post.Blog))]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
