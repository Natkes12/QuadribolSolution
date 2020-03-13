using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class TimeCompetidorRepository : ITimeCompetidorRepository
    {
        public Task<DataResponse<TimeCompetidor>> GetData()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(TimeCompetidor timeCompetidor)
        {
            throw new NotImplementedException();
        }
    }
}
