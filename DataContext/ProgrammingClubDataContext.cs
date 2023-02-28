using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet<AnnouncementModel> Announcements { get; set; }
        public DbSet<MemberModel> Members { get; set; }

        public DbSet<CodeSnippetModel> CodeSnippets { get; internal set; }
        public DbSet<MembershipModel> Memberships { get; set; }

        public DbSet<MembershipTypeModel> MembershipTypes { get; internal set; }
    }
}
