using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    public class Order
    {
        public int id { get; set; }
        public long OrderNo { get; set; }
        public double Amount { get; set; }
    }
}
