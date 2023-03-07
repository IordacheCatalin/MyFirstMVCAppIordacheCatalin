using MyFirstMVCAppIordacheCatalin.Models;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCAppIordacheCatalin.ViewModels
{
    public class MemberCodesnippetsViewModel
    {
        public string Name { get; set; } 
        public string Title { get; set; }
        public string Positios { get; set; }
        public List<CodeSnippetModel> CodeSnippets = new List<CodeSnippetModel>();

    }
}
