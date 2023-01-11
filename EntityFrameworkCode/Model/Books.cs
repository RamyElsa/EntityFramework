using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode.Model
{
    public class Books
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string BookName { get; set; }
        public int Price { get; set; }

       // public int? AuthorId { get; set; }
        public  Authors  Aouthors { get; set; }

    }
}
