using BLL.Interfaces;
using DAO;
using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class TimeService : ITimeService
    {
        private ITimeRepository _timeRepository;

        public TimeService(ITimeRepository timeRepository)
        {
            this._timeRepository = timeRepository;
        }
        public async Task<Response> Insert(Time time)
        {
            Response response = new Response();

            if (time.Competidor.Length < 7)
            {
                response.Erros.Add("O time deve ter 7 competidores!");
            }


            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _timeRepository.Insert(time);
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
        public async Task<DataResponse<Time>> GetTimes()
        {
            List<Time> time = new List<Time>();
            DataResponse<Time> response = new DataResponse<Time>();

            if (time.Count <= 0)
            {
                response.Erros.Add("Nenhum time adicionado!");
                response.Sucesso = false;
                return response;
            }
            try
            {
                return await _timeRepository.GetTimes();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

    }
}
