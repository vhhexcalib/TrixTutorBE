﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.CoursesDTO
{
    public class AllCoursesDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int TeachingSlots { get; set; }
        public decimal TotalPrice { get; set; }
        public string Images { get; set; }
        public DateTime CreateDate { get; set; }
        public string TeachingPlace { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsLocked { get; set; }
        public string TutorId { get; set; }
        public int TeachingDateId { get; set; }
        public int TeachingTimeId { get; set; }
    }
}
