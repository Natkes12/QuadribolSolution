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
            else if (competidor.Nome.Length < 2 || competidor.Nome.Length > 50)
            {
                response.Erros.Add("O nome do competidor deve ser informado.");
            }

            if (competidor.Escolaridade < Entity.Enums.Escolaridade.Quarto)
            {
                response.Erros.Add("Para se inscrever como competidor o aluno deve estar cursando no mínimo o quarto ano.");
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

        public async Task<Response> Update(Competidor competidor)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(competidor.Nome))
            {
                response.Erros.Add("O nome do competidor deve ser informado.");
            }
            else if (competidor.Nome.Length < 2 || competidor.Nome.Length > 50)
            {
                response.Erros.Add("O nome do competidor deve ser informado.");
            }

            if (competidor.Escolaridade < Entity.Enums.Escolaridade.Quarto)
            {
                response.Erros.Add("Para se inscrever como competidor o aluno deve estar cursando no mínimo o quarto ano.");
            }

            if (competidor.Casa != competidor.Time.Casa)
            {
                response.Erros.Add("A casa do competidor é diferente da casa do time!");
            }

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _competidorRepository.Update(competidor);
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

        public Task<Response> Delete(Competidor competidor)
        {
            throw new NotImplementedException();
        }

        public async Task<Competidor> GetByID(int id)
        {
            try
            {
                return await _competidorRepository.GetByID(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }
    }
}
