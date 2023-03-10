using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCAppIordacheCatalin.Models
{
    public class CodeSnippetModel
    {

        [Key]
        public Guid IdCodeSnippet { get; set; }

        [StringLength(100, ErrorMessage = "This field contains max 100 char")]
        public string Title { get; set; }

        public string ContentCode { get; set; }

        public Guid IDMember { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="Revision number must be positive!")]
        public int Revision { get; set; }

        public DateTime DateTimeAdded { get; set; }

        public bool IsPublished { get; set; }

    }
}
