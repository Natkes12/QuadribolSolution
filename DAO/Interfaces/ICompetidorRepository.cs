using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ICompetidorRepository
    {
        Task<Response> Insert(Competidor competidor);
        Task<DataResponse<Competidor>> GetCompetidores();
        Task<Competidor> GetByID(int id);
        Task<Response> Update(Competidor competidor);
    }
}
