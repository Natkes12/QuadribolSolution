using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CompetidorRepository : ICompetidorRepository
    {
        private readonly QuadribolContext context;

        public CompetidorRepository(QuadribolContext context)
        {
            this.context = context;
        }

        public async Task<DataResponse<Competidor>> GetCompetidores()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(Competidor competidor)
        {
            throw new NotImplementedException();
        }
    }
}
