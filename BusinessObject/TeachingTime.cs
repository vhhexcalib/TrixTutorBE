using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class TeachingTime
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string TeachingTimes { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
        public TeachingTime()
        {
            Courses = new HashSet<Courses>();
        }
    }
}
