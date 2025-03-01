using BusinessLogic.Services;
using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITrainService, TrainService>();
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<RailwayContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

await app.RunAsync();
