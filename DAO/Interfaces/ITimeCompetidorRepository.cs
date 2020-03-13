using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ITimeCompetidorRepository
    {
        Task<Response> Insert(TimeCompetidor timeCompetidor);
        Task<DataResponse<TimeCompetidor>> GetData();
    }
}
