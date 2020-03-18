using Entity;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimeService
    {
        Task<Response> Insert(Time time);
        Task<Response> Update(Time time);
        Task<Response> Delete(Time time);
        Task<DataResponse<Time>> GetTimes();
        Task<Time> GetByCasa(Casa casa);

    }
}
