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

        // Danh sách gia sư thuộc danh mục này
        public virtual ICollection<TutorInformation> TutorInformations { get; set; }

        // Danh sách các giao dịch thuê liên quan đến danh mục này
        public virtual ICollection<Renting> Rentings { get; set; }

        public TutorCategory()
        {
            TutorInformations = new HashSet<TutorInformation>();
            Rentings = new HashSet<Renting>();
        }
    }
}
