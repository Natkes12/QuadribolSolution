using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IJogoTimeRepository
    {
        Task<Response> Insert(int jogoID, int timeID);
        Task<DataResponse<JogoTime>> GetData();
    }
}
