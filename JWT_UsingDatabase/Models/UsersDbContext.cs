using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_UsingDatabase.Models
{
    public class UsersDbContext:DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }

        public DbSet<Users> User { get; set; }
    }
}
