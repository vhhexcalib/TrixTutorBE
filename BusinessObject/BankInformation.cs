using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BankInformation
    {
        [Key]
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; }
        public virtual TutorInformation TutorInformation { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public string OwnerName { get; set; }


    }
}
