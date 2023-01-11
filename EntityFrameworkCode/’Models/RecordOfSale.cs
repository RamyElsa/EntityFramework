using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode._Models
{
    public class RecordOfSale
    {
        public int RecordOfSaleId { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }
        public string CarState { get; set; }
        public string CarLicensaplate { get; set; }
        public Car car { get; set; }
    }
}
