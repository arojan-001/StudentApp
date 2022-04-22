using Student.DAL.EF;
using Student.DAL.Entities;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public IQueryable<ClientProfile> GetClientList(string address)
        {
            if (String.IsNullOrEmpty(address))
            {
                return Database.ClientProfiles;
            }
            return Database.ClientProfiles.Where(p => p.Address == address);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
