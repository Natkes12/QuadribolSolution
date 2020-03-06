﻿using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly QuadribolContext _context;

        public UsuarioRepository(QuadribolContext context)
        {
            this._context = context;
        }
        public async Task<Usuario> Autenticar(string email, string senha)
        {
            Response response = new Response();
            Usuario user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
            if (user == null)
            {
                throw new Exception("Email e/ou senha inválidos");
            }
            return user;
        }

        public async Task<Response> Insert(Usuario usuario)
        {
            Response response = new Response();

            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("UQ"))
                {
                    response.Erros.Add("Usuário já existente");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados.");
                }
                response.Sucesso = false;
            }

            return response;
        }
    }
}
