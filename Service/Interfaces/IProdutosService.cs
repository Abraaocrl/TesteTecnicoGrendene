using TesteTecnicoGrendene.Domain.Produtos;

namespace TesteTecnicoGrendene.Service.Interfaces
{
    public interface IProdutosService
    {
        Task<IEnumerable<Produto>> GetProdutos();
    }
}
