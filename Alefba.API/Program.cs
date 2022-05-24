using Alefba.API.BackgroundServices;
using Alefba.API.Middleware;
using Alefba.Application;
using Alefba.Infrastructure;
using Alefba.Infrastructure.MongoDb;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alefba assessment API", Version = "v1" });
});

builder.Services.ConfigureInfrastructureMongoDbServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigureApplicationServices();

builder.Services.AddHostedService<GetCurrencyRateBackgroundService>();
builder.Services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alefba.API v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
