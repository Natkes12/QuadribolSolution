﻿using BLL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    class TimeService : ITimeService
    {
        public Task Insert(Time time)
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
                using (QuadribolContext db = new QuadribolContext())
                {
                    db.Competidores.Add(item);
                    db.SaveChanges();
                }
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
        public Task<List<Time>> GetTimes()
        {
            List<Time> time = new List<Time>();
            DataResponse<Competidor> response = new DataResponse<Competidor>();

            if (time.Count <= 0)
            {
                response.Erros.Add("Nenhum competidor adicionado!");
                response.Sucesso = false;
                return response;
            }
            try
            {
                using (QuadribolContext context = new QuadribolContext())
                {
                    return await context.Competidores.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

    }
}