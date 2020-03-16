using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IJogoTimeService
    {
        Task<Response> Insert(JogoTime jogoTime);
        Task<Response> Update(JogoTime jogoTime);
        Task<Response> Delete(JogoTime jogoTime);
        Task<DataResponse<JogoTime>> GetData();
    }
}

