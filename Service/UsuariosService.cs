using TesteTecnicoGrendene.Domain.Usuarios;
using TesteTecnicoGrendene.Helpers;
using TesteTecnicoGrendene.Helpers.Interfaces;
using TesteTecnicoGrendene.Repository.Interfaces;
using TesteTecnicoGrendene.Service.Interfaces;

namespace TesteTecnicoGrendene.Service
{
    public class UsuariosService : IUsuarioService
    {
        private IUsuariosRepository usuariosRepository;
        private IPasswordHelper passwordHelper;

        public UsuariosService(IUsuariosRepository usuariosRepository, IPasswordHelper passwordHelper)
        {
            this.usuariosRepository = usuariosRepository;
            this.passwordHelper = passwordHelper;
        }

        public async Task<string> Login(string email, string senha)
        {
            var usuarioLogado = await usuariosRepository.GetByEmail(email);

            if(usuarioLogado == null || !passwordHelper.VerifyPassword(usuarioLogado.Senha, senha))
            {
                return null;
            }

            var token = AuthHelper.GenerateJWTToken(usuarioLogado);

            return token;
        }

        public async Task<Usuario> Cadastrar(string email, string nome, string senha)
        {

            var usuario = new Usuario()
            {
                Email = email,
                Nome = nome,
                Senha = senha,
                Ativo = true,
                DataCriacao = DateTime.Now,
            };

            var hashSenha = passwordHelper.HashPassword(senha);

            usuario.Senha = hashSenha;

            usuario = await usuariosRepository.Create(usuario);

            return usuario;
        }

        public async Task<bool> Remover(int id)
        {
            var remocao = await usuariosRepository.Delete(id);

            return remocao;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var usuario = await usuariosRepository.GetByEmail(email);

            return usuario;
        }
    }
}
