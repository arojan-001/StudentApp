using Microsoft.AspNet.Identity.EntityFramework;
using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("DefaultConnection", throwIfV1Schema: false) { }
        public ApplicationContext(string conectionString) : base(conectionString,throwIfV1Schema : false) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        
    }
}
