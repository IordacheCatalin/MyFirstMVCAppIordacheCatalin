using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;

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
            _context.Members.Remove(member);
            _context.SaveChanges();
        }


    }
}
