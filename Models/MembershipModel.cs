using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCAppIordacheCatalin.Models
{
    public class MembershipModel
    {

        [Key]
        public Guid? IDMembership { get; set; }

        public Guid? IDMember { get; set; }

        public Guid? IDMembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Level { get; set; }


    }
}
