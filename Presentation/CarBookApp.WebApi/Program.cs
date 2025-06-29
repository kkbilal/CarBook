using Application.Features.Handlers.AboutHandlers;
using Application.Features.Handlers.BannerHandlers;
using Application.Features.Handlers.BrandHandlers;
using Application.Interfaces;

using CarBookApp.Persistence.Context;
using CarBookApp.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped< GetAboutByIdQueryHandler>();
builder.Services.AddScoped< GetAboutQueryHandler>();
builder.Services.AddScoped< UpdateAboutCommandHandler>();
builder.Services.AddScoped< RemoveAboutCommandHandler>();
builder.Services.AddScoped< CreateAboutCommandHandler>();

builder.Services.AddScoped< GetBannerByIdQueryHandler>();
builder.Services.AddScoped< GetBannerQueryHandler>();
builder.Services.AddScoped< UpdateBannerCommandHandler>();
builder.Services.AddScoped< RemoveBannerCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();

builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
