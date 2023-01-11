using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode
{
    public class Employee
    {
        public byte Id { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }
    }
}
