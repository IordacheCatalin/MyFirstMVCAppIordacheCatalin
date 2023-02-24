using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.Repositories
{
    public class AnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public AnnouncementsRepository(ProgrammingClubDataContext context) { 
        
       _context = context;

        }

        public DbSet<AnnouncementModel> GetAnnouncements()
        {
            return _context.Announcements;
        }
    }
}
