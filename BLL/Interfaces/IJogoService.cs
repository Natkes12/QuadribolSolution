using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IJogoService
    {
        Task<Response> Insert(Jogo jogo);
        Task<DataResponse<Jogo>> GetJogos();
    }
}
