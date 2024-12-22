using TesteTecnicoGrendene.Domain.Usuarios;

namespace TesteTecnicoGrendene.Helpers.Interfaces
{
    public interface IPasswordHelper
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}
