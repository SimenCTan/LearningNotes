using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// write a api client to mongodb and get data
app.MapGet("/GetMovie/{runtime}", async (int runtime) =>
{
    var client = new MongoClient("mongodb+srv:url");
    var database = client.GetDatabase("sample_mflix");
    var collection = database.GetCollection<Movie>("movies");
    var movie = await collection.Find(x => x.Runtime == runtime).FirstOrDefaultAsync();
    return movie;
})
.WithName("GetMovie")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

[BsonIgnoreExtraElements]
public class Movie
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; } = null!;

    [BsonElement("year")]
    public int Year { get; set; }

    [BsonElement("runtime")]
    public int Runtime { get; set; }

    [BsonElement("plot")]
    [BsonIgnoreIfNull]
    public string Plot { get; set; } = null!;

    [BsonElement("cast")]
    [BsonIgnoreIfNull]
    public List<string> Cast { get; set; } = null!;

}
