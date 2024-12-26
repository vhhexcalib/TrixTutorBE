using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TutorContact
    {
        [Key]
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; }
        public virtual TutorInformation TutorInformation { get; set; } 
        public string FacebookURL {  get; set; }
        public string InstagramURL { get; set; }
        public string XURL { get; set; }
        public string LinkedIn { get; set; }

    }
}
