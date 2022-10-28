using System.Reflection;
using AutoMapper;
using Common.AutoMapperProfile;
using Domain.Services.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository.DataBase.Context;
using Repository.Repository.Product;
using Repository.Repository.Views;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IViewProductsCatalogRepository, ViewProductsCatalogRepository>();


builder.Services.AddTransient<IProductServices, ProductServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();

    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var configMapper = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperProfile());
});

var mapper = configMapper.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "APIS",
        Description = "MICROSERVICIO PRODUCTS ASP.NET Core API"
    });

    //importante para definir la documentacion de swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    //importante para definir la documentacion de swagger
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
