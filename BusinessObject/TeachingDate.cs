using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TeachingDate
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string TeachingDates { get; set; }
    }
}