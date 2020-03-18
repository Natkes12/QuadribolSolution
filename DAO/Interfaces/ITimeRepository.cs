using Entity;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ITimeRepository
    {
        Task<Response> Insert(Time time);
        Task<DataResponse<Time>> GetTimes();
        Task<Time> GetByCasa(Casa casa);
        Task<Time> GetByID(int id);
    }
}
