using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Certification { get; set; }
        public bool Verified { get; set; }
        public DateOnly UploadedAt { get; set; }
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; } 
        public virtual TutorInformation TutorInformation { get; set; }
    }
}
