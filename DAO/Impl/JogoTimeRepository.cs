using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class JogoTimeRepository : IJogoTimeRepository
    {
        public Task<DataResponse<JogoTime>> GetData()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(JogoTime jogoTime)
        {
            throw new NotImplementedException();
        }
    }
}
