using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    public class Relation
    {
        public int Id { get; set; }
        public string Url { get; set; }
        // one to one 
        // public RetaionImage retaionImage { get; set; }

        //one to Many
        //public List<RetaionImage> RetaionImages { get; set;}
    }
}
