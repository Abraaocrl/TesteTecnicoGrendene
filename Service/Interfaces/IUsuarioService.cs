using TesteTecnicoGrendene.Domain.Usuarios;

namespace TesteTecnicoGrendene.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> Login(string email, string senha);

        Task<Usuario> Cadastrar(string email, string nome, string senha);

        Task<bool> Remover(int id);

        Task<Usuario> GetByEmail(string email);
    }
}
