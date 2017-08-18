using CoreFacade.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreContext
{
    public class RepoContext : DbContext
    {
        //Used for testing
        public RepoContext() { }

        public RepoContext(DbContextOptions<RepoContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserToken> UserToken { get; set; }

        public DbSet<LookupModel> LookupModel { get; set; }
    }
}
