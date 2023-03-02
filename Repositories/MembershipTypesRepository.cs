using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.Repositories
{
    public class MembershipTypesRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipTypesRepository(ProgrammingClubDataContext context)
        {

            _context = context;

        }

        //GET ALL FROM TABLE SECTION 
        public DbSet<MembershipTypeModel> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }

          //GET CODE FOR A CERTAIN ID
        public MembershipTypeModel GetMembershipTypeById(Guid id)
        {
           MembershipTypeModel membershipType = _context.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == id);
            return membershipType;
        }

        //ADD SECTION
        public void Add(MembershipTypeModel model)
        {
            model.IDMembershipType = Guid.NewGuid();
            _context.MembershipTypes.Add(model);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void Update(MembershipTypeModel model)
        {
            _context.MembershipTypes.Update(model);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void Delete(Guid id)
        {
            MembershipTypeModel membershipType = GetMembershipTypeById(id);
            _context.MembershipTypes.Remove(membershipType);
            _context.SaveChanges();
        }
    }
}
