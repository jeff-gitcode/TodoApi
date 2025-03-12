using MediatR;
using TodoApi.Extensions;
using TodoApi.Middleware;
using Application.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddApplicationServices(builder.Configuration["Jwt:key"]);
// Add services to the container.
builder.Services.AddScoped<IJwtService>(provider =>
    new JwtService(builder.Configuration["Jwt:Key"], double.Parse(builder.Configuration["Jwt:ExpiryDuration"])));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();