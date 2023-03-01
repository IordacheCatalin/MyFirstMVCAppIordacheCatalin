﻿using Microsoft.EntityFrameworkCore;
using MyFirstMVCAppIordacheCatalin.Models;

namespace MyFirstMVCAppIordacheCatalin.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet<AnnouncementModel> Announcements { get; set; }
        public DbSet<MemberModel> Members { get; set; }

        public DbSet<CodeSnippetModel> CodeSnippets { get; set; }
        public DbSet<MembershipModel> Memberships { get; set; }

        public DbSet<MembershipTypeModel> MembershipTypes { get; set; }

        internal void AnnounUpdate(AnnouncementModel model)
        {
            throw new NotImplementedException();
        }
    }
}
