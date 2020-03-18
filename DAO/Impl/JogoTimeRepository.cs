using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class JogoTimeRepository : IJogoTimeRepository
    {
        private readonly QuadribolContext _context;
        private ITimeRepository _time;
        private IJogoRepository _jogo;

        public JogoTimeRepository(QuadribolContext context, IJogoRepository jogo, ITimeRepository time)
        {
            this._context = context;
            this._time = time;
            this._jogo = jogo;
        }

        public Task<DataResponse<JogoTime>> GetData()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(int jogoID, int timeID)
        {
            Response response = new Response();
            Time time = new Time();
            Jogo jogo = new Jogo();
            JogoTime jogoTime = new JogoTime();

            try
            {
                time = await this._time.GetByID(timeID);
                jogo = await this._jogo.GetByID(jogoID);

                jogoTime.Jogo = jogo;
                jogoTime.Time = time;

                time.JogosTime.Add(jogoTime);
                jogo.JogosTime.Add(jogoTime);
                this._context.Jogos.Update(jogo);
                this._context.Times.Update(time);
                await this._context.SaveChangesAsync();

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Erros.Add("Erro no banco de dados, contate o administrador.");
                File.WriteAllText("log.txt", ex.Message + " " + ex.StackTrace);
            }

            return response;

        }
    }
}
