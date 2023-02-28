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

        public DbSet<CodeSnippetModel> GetCodeSnippets()
        {
            return _context.CodeSnippets;
        }

    }
}
