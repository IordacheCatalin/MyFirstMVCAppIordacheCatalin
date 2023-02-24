using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCAppIordacheCatalin.Models
{
    public class MembershipType
    {

        [Key]
        public Guid? IDMembershipType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SubscriptionLengthInMonths { get; set; }

    }
}
