using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.MigrationServices;
using Company.Domain.Repositories;

namespace Company.Infrast.Repositories
{
    public class ServiceRepository : Repository<MigrationService>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
