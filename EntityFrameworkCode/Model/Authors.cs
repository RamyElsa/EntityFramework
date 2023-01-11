using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCode.Model
{
    public class Authors
    {
        public int Id { get; set; }
        [Required , MaxLength(200)]
        public string AuthorName { get; set; }

        public int? NationalityId { get; set; }

        public  Nationality Nationality { get; set; }
    }
}
