using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IJogoRepository
    {
        Task<Response> Insert(Jogo jogo);
        Task<DataResponse<Jogo>> GetJogos();
        Task<Jogo> GetByID(int id);
        Task<int> GetJogoID(Jogo jogo);
    }
}
