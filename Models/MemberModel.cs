using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCAppIordacheCatalin.Models
{
    public class MemberModel
    {

        [Key]
        public Guid IDMember { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Position { get; set; }
        public string Description { get; set; }

        public string Resume { get; set; }

       }
}
