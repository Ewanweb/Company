using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.Consultations;
using Company.Domain.Repositories;

namespace Company.Infrast.Repositories
{
    public class ConsulationRepository : Repository<ConsultationRequest>, IConsulationRepository
    {
        public ConsulationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
