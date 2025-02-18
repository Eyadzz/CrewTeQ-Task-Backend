using API.Configurations;
using Application;
using Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddSwagger();
builder.Services.AddControllers();

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

await DatabaseStartupConfigurator.ApplyMigrations(app);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();