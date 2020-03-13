using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimeCompetidorService
    {
        Task<Response> Insert(TimeCompetidor timeCompetidor);
        Task<Response> Update(TimeCompetidor timeCompetidor);
        Task<Response> Delete(TimeCompetidor timeCompetidor);
        Task<DataResponse<TimeCompetidor>> GetData();
    }
}
