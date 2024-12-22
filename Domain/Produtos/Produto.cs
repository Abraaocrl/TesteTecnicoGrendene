using System.Text.Json.Serialization;

namespace TesteTecnicoGrendene.Domain.Produtos
{
    public class Produto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("brand")]
        public string Marca { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("price")]
        public decimal? Preco { get; set; }

        [JsonPropertyName("price_sign")]
        public string SimboloPreco { get; set; }

        [JsonPropertyName("currency")]
        public string Moeda { get; set; }

        [JsonPropertyName("image_link")]
        public string LinkImagem { get; set; }

        [JsonPropertyName("product_link")]
        public string LinkProduto { get; set; }

        [JsonPropertyName("website_link")]
        public string LinkWebsite { get; set; }

        [JsonPropertyName("description")]
        public string Descrição { get; set; }

        [JsonPropertyName("rating")]
        public double? Avaliacao { get; set; }

        [JsonPropertyName("category")]
        public string Categoria { get; set; }

        [JsonPropertyName("product_type")]
        public string Tipo { get; set; }

        [JsonPropertyName("tag_list")]
        public List<string> ListaTags { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime DataAtualizacao { get; set; }

        [JsonPropertyName("product_api_url")]
        public string UrlApiProduto { get; set; }

        [JsonPropertyName("api_featured_image")]
        public string ImagemDestaqueApi { get; set; }

        [JsonPropertyName("product_colors")]
        public List<ProdutoCor> Cores { get; set; }
    }
}
