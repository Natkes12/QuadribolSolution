﻿using BLL.Impl;
using BLL.Interfaces;
using DAO;
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

        private CompetidorRepository repository = new CompetidorRepository();

        public async Task<Response> Insert(Competidor competidor)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(competidor.Nome))
            {
                response.Erros.Add("O nome do competidor deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(competidor.Escolaridade))
            {
                response.Erros.Add("A escolaridade deve ser informada.");
            }

            if (competidor.Escolaridade.Length < 4)
            {
                response.Erros.Add("O competidor deve ter escolaridade de no mínimo 4.");
            }

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                repository.Insert(competidor);
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
                return await repository.GetCompetidores();
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
