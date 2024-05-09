using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.Review
{
    public class UserReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Message { get; set; }
    }
}
