using Microsoft.AspNetCore.Mvc;
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

        public DbSet<MembershipTypeModel> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }
    }
}
