using HRProject_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRProject_BackEnd.Presistence
{
    public class CommitteeDBContext : DbContext
    {
        public CommitteeDBContext(DbContextOptions<CommitteeDBContext> options)
            : base(options)
        {

        }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
