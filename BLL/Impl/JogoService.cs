using BLL.Interfaces;
using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class JogoService : IJogoService
    {
        private IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            this._jogoRepository = jogoRepository;
        }

        public async Task<Response> Insert(Jogo jogo)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _jogoRepository.Insert(jogo);
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Erros.Add("Erro no banco de dados, contate o administrador.");
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                return response;
            }
        }

        public async Task<DataResponse<Jogo>> GetJogos()
        {
            List<Jogo> jogo = new List<Jogo>();
            DataResponse<Jogo> response = new DataResponse<Jogo>();

            if (jogo.Count <= 0)
            {
                response.Erros.Add("Nenhum competidor adicionado!");
                response.Sucesso = false;
                return response;
            }
            try
            {
                return await _jogoRepository.GetJogos();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public Task<Response> Update(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Delete(Jogo jogo)
        {
            throw new NotImplementedException();
        }
    }
}
