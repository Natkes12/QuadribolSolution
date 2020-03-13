using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IJogoTimeRepository
    {
        Task<Response> Insert(JogoTime jogoTime);
        Task<DataResponse<JogoTime>> GetData();
    }
}
