using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Rating { get; set; }
        public string TotalReport { get; set; }
        public string FeedbackContent { get; set; }

        [ForeignKey("Account")]
        public int FeedbackById { get; set; }
        public virtual Account Account { get; set; }
    }
}
