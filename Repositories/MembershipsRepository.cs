using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.Repositories
{
    public class MembershipsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipsRepository(ProgrammingClubDataContext context)
        {

            _context = context;

        }

        //GET ALL FROM TABLE SECTION 

        public DbSet<MembershipModel> GetMemberships()
        {
            return _context.Memberships;
        }

        //GET CODE FOR A CERTAIN ID

        public MembershipModel GetMembershipById(Guid id)
        {
            MembershipModel membership = _context.Memberships.FirstOrDefault(x => x.IDMembership == id);
            return membership;
        }

        //ADD SECTION
        public void AddMembership(MembershipModel model)
        {
            model.IDMembership = Guid.NewGuid();
            _context.Memberships.Add(model);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void UpdateMembership(MembershipModel model)
        {
            _context.Memberships.Update(model);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void DeleteMembership(Guid id)
        {
            MembershipModel membership = GetMembershipById(id);
            _context.Memberships.Remove(membership);
            _context.SaveChanges();
        }
    }
}
