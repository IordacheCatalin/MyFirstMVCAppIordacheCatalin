using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet<AnnouncementModel> Announcements { get; set; }

        //public DbSet<CodeSnippetsModel> codeSnippets { get; set; }

        //public DbSet<MembersModel> Members { get; set; }

        //public DbSet<MembershipsModel> Memberships { get; set; }

        //public DbSet<MembershipsTypesModel> MembershipsTypes { get; set; }



    }
}
