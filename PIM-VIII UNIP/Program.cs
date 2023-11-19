using Microsoft.EntityFrameworkCore;
using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;
using PIM_VIII_UNIP.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Adicionando Dependências
builder.Services.AddScoped<IRepository<Carrinho>, CarrinhoRepository>();
builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<Endereco>, EnderecoRepository>();
builder.Services.AddScoped<IRepository<ItemCarrinho>, ItemCarrinhoRepository>();
builder.Services.AddScoped<IRepository<Produto>, ProdutoRepository>();
builder.Services.AddScoped<IRepository<Vendedor>, VendedorRepository>();

//Adicionando configuração de conexão com o Banco de Dados SQLServer
builder.Services.AddDbContext<MarketPlaceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectSqlServer"));
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
