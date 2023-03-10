using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.ViewModels;

namespace MyFirstMVCAppIordacheCatalin.Repositories
{
    public class MembersRepository
    {

        private readonly ProgrammingClubDataContext _context;
        public MembersRepository(ProgrammingClubDataContext context)
        {

            _context = context;

        }

        //GET ALL FROM TABLE SECTION 
        public DbSet<MemberModel> GetMembers()
        {
            return _context.Members;
        }

        //GET CODE FOR A CERTAIN ID
        public MemberModel GetMemberById(Guid id)
        {
            MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember == id);
            return member;
        }

        //ADD SECTION
        public void Add(MemberModel model)
        {
            model.IDMember = Guid.NewGuid();
            _context.Members.Add(model);
            _context.SaveChanges();
        }

        //UPDATE SECTION
        public void Update(MemberModel model)
        {
            _context.Members.Update(model);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void Delete(Guid id)
        {
            MemberModel member = GetMemberById(id);
            if(member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
            
        }

        //METODA CARE INCARCA DATE (members) IN ViewModel codesnippets

        public MemberCodesnippetsViewModel GetMemberCodeSnippets(Guid memberID)

        {
            MemberCodesnippetsViewModel memberCodesnippetsViewModel = new MemberCodesnippetsViewModel();

            MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember.Equals(memberID));
            if (member != null)
            {
                memberCodesnippetsViewModel.Name = member.Name;

                memberCodesnippetsViewModel.Positios = member.Position;

                memberCodesnippetsViewModel.Title = member.Title;

                IQueryable<CodeSnippetModel> memberCodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == memberID);//IQueruable se foloseste atunci cand avem de facut filtrari custom
                foreach (CodeSnippetModel dbCodeSnippet in memberCodeSnippets)
                {
                    memberCodesnippetsViewModel.CodeSnippets.Add(dbCodeSnippet);
                }

                //memberCodesnippetsViewModel.CodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == memberID).ToList();//Incarca toata baza de date.
            }
            return memberCodesnippetsViewModel;

        }
    }
}
