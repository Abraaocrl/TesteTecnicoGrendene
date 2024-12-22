using TesteTecnicoGrendene.Domain.Usuarios;

namespace TesteTecnicoGrendene.Repository.Interfaces
{
    public interface IUsuariosRepository
    {
        public Task<Usuario> Login(string email, string senha);

        public Task<Usuario> GetByEmail(string email);

        public Task<Usuario> Create(Usuario usuario);

        public Task<Usuario> Update(Usuario usuario);

        public Task<bool> Delete(int id);
    }
}
