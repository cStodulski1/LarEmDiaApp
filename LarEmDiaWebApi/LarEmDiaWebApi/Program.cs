
using LarEmDia.Application.Categorias.CadastrarCategoria;
using LarEmDia.Application.Categorias.ListarCategoria;
using LarEmDia.Application.Pessoas.AtualizarPessoa;
using LarEmDia.Application.Pessoas.BuscarPessoaPorId;
using LarEmDia.Application.Pessoas.CadastrarPessoa;
using LarEmDia.Application.Pessoas.ExcluirPessoa;
using LarEmDia.Application.Pessoas.ListarPessoas;
using LarEmDia.Application.Relatorios.ListaPessoasTotais;
using LarEmDia.Application.Relatorios.PessoasTotalSumario;
using LarEmDia.Application.Transacoes.CadastrarTransacao;
using LarEmDia.Infrastructure.Data;
using LarEmDia.Infrastructure.Interfaces;
using LarEmDia.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(CadastrarPessoaHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(AtualizarPessoaHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(ExcluirPessoaHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(BuscarPessoaPorIdHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(ListarPessoasHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(CadastrarCategoriaHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(ListarCategoriaHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(CadastrarTransacaoHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(PessoasTotalSumarioHandler).Assembly)
        .RegisterServicesFromAssembly(typeof(ListarPessoasTotaisHandler).Assembly)
      );

//aqui eu estabeleço a conexão com o banco de dados adicionando o dbContext
//e passando as opções de configuração
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
