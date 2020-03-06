using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface INarradorRepository
    {
        Task<Response> Insert(Narrador narrador);
        Task<DataResponse<Narrador>> GetNarradores(); 
    }
}
