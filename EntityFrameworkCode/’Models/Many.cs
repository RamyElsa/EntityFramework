using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    public class Many
    {
        public int ManyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<ManytoMany> TagsMany { get; set; }
        public List<CollectTable> PT_Maines { get; set; }
    }
}
