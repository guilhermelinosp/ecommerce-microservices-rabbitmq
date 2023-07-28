using ECommerce.API.Mappings;
using ECommerce.API.Repositories;
using ECommerce.API.Repositories.Context;
using ECommerce.API.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration["SqlServer:ConnectionString"]));

builder.Services.AddScoped<IProductRepository, ProductRepositoryImp>();
builder.Services.AddScoped<ICartRepository, CartRepositoryImp>();
builder.Services.AddScoped<ICouponRepository, CouponRepositoryImp>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(AutoMapping.Initialize().CreateMapper());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();