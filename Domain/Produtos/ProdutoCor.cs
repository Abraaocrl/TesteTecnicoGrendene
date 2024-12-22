using System.Text.Json.Serialization;

namespace TesteTecnicoGrendene.Domain.Produtos
{
    public class ProdutoCor
    {
        [JsonPropertyName("hex_value")]
        public string ValorHex { get; set; }

        [JsonPropertyName("colour_name")]
        public string Nome { get; set; }
    }
}
