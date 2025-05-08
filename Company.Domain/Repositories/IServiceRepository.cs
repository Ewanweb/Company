using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.MigrationServices;

namespace Company.Domain.Repositories
{
    public interface IServiceRepository : IRepository<MigrationService>
    {
    }
}
