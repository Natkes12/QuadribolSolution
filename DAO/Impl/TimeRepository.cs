using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class TimeRepository : ITimeRepository
    {
        private readonly QuadribolContext _context;

        public TimeRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public Task<DataResponse<Time>> GetTimes()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Time time)
        {
            throw new NotImplementedException();
        }
    }
}
