using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    public class ManytoMany
    {
        public int ManytoManyId { get; set; }
        public ICollection<Many> PostMany { get; set; }
        public List<CollectTable> PT_Maines { get; set; }
    }
}
