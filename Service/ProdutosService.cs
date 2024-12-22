using TesteTecnicoGrendene.Domain.Produtos;
using TesteTecnicoGrendene.Service.Interfaces;

namespace TesteTecnicoGrendene.Service
{
    public class ProdutosService : IProdutosService
    {
        private readonly string UrlAPIProdutos;

        public ProdutosService()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            UrlAPIProdutos = configuration.GetConnectionString("ApiProdutos");
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            var resultado = await new HttpClient().GetFromJsonAsync<IEnumerable<Produto>>(UrlAPIProdutos);

            return resultado;
        }
    }
}
