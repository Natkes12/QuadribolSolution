using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IJogoTimeService
    {
        Task<Response> Insert(int jogoID, int timeID);
        Task<Response> Update(int jogoID, int timeID);
        Task<Response> Delete(int jogoID, int timeID);
        Task<DataResponse<JogoTime>> GetData();
    }
}

