using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCAppIordacheCatalin.Models
{
    public class MembershipModel
    {

        [Key]
        public Guid IDMembership { get; set; }

        public Guid IDMember { get; set; }

        public Guid IDMembershipType { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        public DateTime EndDate { get; set; }

        public int Level { get; set; }


    }
}
