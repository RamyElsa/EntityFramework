using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    public class CollectTable
    {
        public int PostManyId { get; set; }
        public Many PostMany { get; set; }
        public int TagsManyId { get; set; }
        public ManytoMany TagsMany { get; set; }
        public DateTime DateNow { get; set; }
    }
}
