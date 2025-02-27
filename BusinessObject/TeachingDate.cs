using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class TeachingDate
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string TeachingDates { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
        public TeachingDate()
        {
            Courses = new HashSet<Courses>();
        }
    }
}
