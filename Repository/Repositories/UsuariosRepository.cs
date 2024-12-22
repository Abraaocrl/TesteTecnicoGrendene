using Microsoft.EntityFrameworkCore;
using TesteTecnicoGrendene.Data;
using TesteTecnicoGrendene.Domain.Usuarios;
using TesteTecnicoGrendene.Repository.Interfaces;

namespace TesteTecnicoGrendene.Repository.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuariosRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            var created = await _appDbContext.Usuarios.AddAsync(usuario);

            await _appDbContext.SaveChangesAsync();

            return created.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _appDbContext.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return false;
            }

            usuario.Ativo = false;

            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var usuario = await _appDbContext.Usuarios.Where(u => u.Email == email && u.Ativo).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            var usuarioLogado = await _appDbContext.Usuarios.Where(u => u.Email == email && u.Senha == senha && u.Ativo).FirstOrDefaultAsync();

            return usuarioLogado;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            var usuarioExistente = await _appDbContext.Usuarios.Where(u => u.Id == usuario.Id).FirstOrDefaultAsync();

            usuarioExistente = usuario;
            usuarioExistente.DataAtualizacao = DateTime.Now;

            _appDbContext.Usuarios.Update(usuarioExistente);

            await _appDbContext.SaveChangesAsync();

            return usuarioExistente;
        }
    }
}
