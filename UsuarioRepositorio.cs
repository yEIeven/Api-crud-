using ApiCrud.Data;
using ApiCrud.Models;
using ApiCrud.Repositorio.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {


        private readonly SistemaTarefasDbContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDbContext SistemaTarefasDbContext)
        {
            _dbContext = SistemaTarefasDbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public async Task<bool> apagar(int id)
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                throw new Exception($"Usuario Para o ID: {id} foi apago no banco de dados");
            }

            _dbContext.Usuarios.Remove(usuarioExistente);
            await _dbContext.SaveChangesAsync();
            return true;


        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                throw new Exception($"Usuario Para o ID: {id} não foi encontrado no banco de dados");

            }
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioExistente);

           await _dbContext.SaveChangesAsync();
           
            return usuarioExistente;
        }
    }
}
