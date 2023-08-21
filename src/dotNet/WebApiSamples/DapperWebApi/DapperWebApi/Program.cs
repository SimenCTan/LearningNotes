using Npgsql;
using Dapper;
using DapperWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("customers", async (IConfiguration config) =>
{
    var connectionStr = config.GetConnectionString("Default");
    var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStr);
    var dataSource = dataSourceBuilder.Build();
    using var conn = await dataSource.OpenConnectionAsync();
    var queryStr = "select *from hangfire.job;";
    var jobs = await conn.QueryAsync<JobQueue>(queryStr);
    return Results.Ok(jobs);
});

app.Run();
