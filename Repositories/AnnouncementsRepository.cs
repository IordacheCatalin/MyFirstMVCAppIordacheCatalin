using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.DataContext;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.Repositories
{
    public class AnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {

            _context = context;

        }


        //GET ALL FROM TABLE SECTION 
        public DbSet<AnnouncementModel> GetAnnouncements()
        {
            return _context.Announcements;
        }

    
        //GET CODE FOR A CERTAIN ID

        public AnnouncementModel GetAnnouncementById(Guid id)
        {
            AnnouncementModel announcement = _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == id);
            return announcement;
        }

        //ADD SECTION
        public void Add(AnnouncementModel model)
        {
            model.IdAnnouncement = Guid.NewGuid();
            _context.Announcements.Add(model);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void Update(AnnouncementModel model)
        {
            _context.Announcements.Update(model);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void Delete(Guid id)
        {
            AnnouncementModel announcement = GetAnnouncementById(id);
            _context.Announcements.Remove(announcement);
            _context.SaveChanges();
        }

    
    }
}
