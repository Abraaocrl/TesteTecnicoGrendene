using Microsoft.EntityFrameworkCore;
using TesteTecnicoGrendene.Data;
using TesteTecnicoGrendene.Repository.Interfaces;
using TesteTecnicoGrendene.Repository.Repositories;
using TesteTecnicoGrendene.Service.Interfaces;
using TesteTecnicoGrendene.Service;

namespace TesteTecnicoGrendene.Configuration
{
    public static class DataConfig
    {
        public static WebApplicationBuilder AddDataConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            builder.Services.AddScoped<IUsuarioService, UsuariosService>();

            builder.Services.AddScoped<IProdutosService, ProdutosService>();

            return builder;
        }
    }
}
