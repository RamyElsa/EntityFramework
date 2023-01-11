using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    // class Retaion one to one 
    public class RetaionImage
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [Required, MaxLength(250)]
        public string Caption { get; set; }

        // Oneway ForeignKey By Default 

        // public int RelationId { get; set; }


        // [ForeignKey("RelationForeign")]
        public int RelationForeign { get; set; }

        public Relation relation { get; set; }
    }

    // class Retaion one to Many 
    /*
    public class RetaionImage
    {
        public int RetaionImageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int RelationId { get; set; }

        //public Relation relation { get; set; }
    }
    */
}
