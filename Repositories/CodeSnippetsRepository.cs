using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public CodeSnippetsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        //GET ALL FROM TABLE SECTION 
        public DbSet<CodeSnippetModel> GetCodeSnippets()
        {
            return _context.CodeSnippets;
        }

        //GET CODE FOR A CERTAIN ID

        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id);
            return codeSnippetModel;
        }

        //ADD SECTION (varianta B , diferit fata de announcements)

        public void AddCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IdCodeSnippet = Guid.NewGuid();

            _context.Entry(codeSnippetModel).State = EntityState.Added; 
            _context.SaveChanges();

        }

        //UPDATE SECTION

        public void UpdateCodeSnippet(CodeSnippetModel model)
        {
            _context.CodeSnippets.Update(model);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void DeleteCodeSnippet(Guid id)
        {
            CodeSnippetModel codeSnippet = GetCodeSnippetById(id);
            if(codeSnippet != null)
            {
                _context.CodeSnippets.Remove(codeSnippet);
                _context.SaveChanges();
            }
           
        }
    }
}
