using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class NarradorRepository : INarradorRepository
    {
        private readonly QuadribolContext _context;

        public NarradorRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public Task<DataResponse<Narrador>> GetNarradores()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Narrador narrador)
        {
            throw new NotImplementedException();
        }
    }
}
