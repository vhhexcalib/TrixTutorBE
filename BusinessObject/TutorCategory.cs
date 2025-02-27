using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class TutorCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int RentingQuantity { get; set; }
        public virtual ICollection<TutorInformation> TutorInformations { get; set; }
        public TutorCategory()
        {
            TutorInformations = new HashSet<TutorInformation>();
        }
    }
}
