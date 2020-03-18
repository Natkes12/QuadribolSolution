using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompetidorService
    {
       Task<Response> Insert(Competidor competidor);
       Task<Response> Update(Competidor competidor);
       Task<Response> Delete(Competidor competidor);
       Task<DataResponse<Competidor>> GetCompetidores();
       Task<Competidor> GetByID(int id);   
    }
}
