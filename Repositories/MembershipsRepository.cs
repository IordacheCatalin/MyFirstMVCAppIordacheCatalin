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
            MembershipModel membershipModel = _context.Memberships.FirstOrDefault(x => x.IDMembership == id);
            return membershipModel;
        }

        //ADD SECTION
        public void AddMembership(MembershipModel membershipModel)
        {
            membershipModel.IDMembership = Guid.NewGuid();
            _context.Memberships.Add(membershipModel);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void UpdateMembership(MembershipModel membershipModel)
        {
            _context.Memberships.Update(membershipModel);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void DeleteMembership(Guid id)
        {
            MembershipModel membershipModel = GetMembershipById(id);
            if(membershipModel != null)
            {
                _context.Memberships.Remove(membershipModel);
                _context.SaveChanges();
            }
            
        }
    }
}
