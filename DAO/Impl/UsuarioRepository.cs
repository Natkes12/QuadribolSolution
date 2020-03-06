using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly QuadribolContext context;

        public UsuarioRepository(QuadribolContext context)
        {
            this.context = context;
        }
        public Task<Response> Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(Usuario usuario)
        {
            Response response = new Response();

            try
            {
                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();
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
