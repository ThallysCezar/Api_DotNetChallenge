using Microsoft.EntityFrameworkCore;
using ProjectAPI.Application.Mappings;
using ProjectAPI.Application.Services;
using ProjectAPI.Domain.Repositories.Interfaces;
using ProjectAPI.Infra.Data.Context;
using ProjectAPI.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.OpenApi.Models;
using ProjectAPI.Application.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMySql = builder.Configuration.GetConnectionString("ConectionMyAPI");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
    connectionStringMySql,
    ServerVersion.Parse("8.0.32-MySQL"))
);

// repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStockItemRepository, StockItemRepository>();

//servicos
builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStockItemService, StockItemService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Challenge Product",
        Description = "An ASP.NET Core Web API for managing Products, Store and StockItems",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
