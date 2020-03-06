using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class JogoRepository : IJogoRepository
    {
        private readonly QuadribolContext _context;

        public JogoRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public Task<DataResponse<Jogo>> GetJogos()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Jogo jogo)
        {
            throw new NotImplementedException();
        }
    }
}
