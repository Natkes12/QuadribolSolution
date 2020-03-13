using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INarradorService
    {
        Task<Response> Insert(Narrador narrador);
        Task<Response> Update(Narrador narrador);
        Task<Response> Delete(Narrador narrador);
        Task<DataResponse<Narrador>> GetNarrador();
    }
}
