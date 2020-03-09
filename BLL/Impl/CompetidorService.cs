using BLL.Impl;
using BLL.Interfaces;
using DAO;
using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL
{
    public class CompetidorService : ICompetidorService
    {
        private ICompetidorRepository _competidorRepository;

        public CompetidorService(ICompetidorRepository competidorRepository)
        {
            this._competidorRepository = competidorRepository;
        }

        public async Task<Response> Insert(Competidor competidor)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(competidor.Nome))
            {
                response.Erros.Add("O nome do competidor deve ser informado.");
            }          

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _competidorRepository.Insert(competidor);
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
        public async Task<DataResponse<Competidor>> GetCompetidores()
        {
            List<Competidor> competidor = new List<Competidor>();
            DataResponse<Competidor> response = new DataResponse<Competidor>();

            if (competidor.Count <= 0)
            {
                response.Erros.Add("Nenhum competidor adicionado!");
                response.Sucesso = false;
                return response;
            }
            try
            {
                return await _competidorRepository.GetCompetidores();
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
