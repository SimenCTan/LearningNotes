using FileUpload.Configurations;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AzureStorageOption>(builder.Configuration.GetSection("AzureStorage"));
AzureStorageOption AzureStorageOption = new();
builder.Configuration.GetSection("AzureStorage").Bind(AzureStorageOption);
builder.Services.AddScoped(_ =>
{
    var blobContainerClient = new BlobContainerClient(AzureStorageOption.StorageConnectionString, AzureStorageOption.ContainerName);
    blobContainerClient.CreateIfNotExists();
    return blobContainerClient;
});
builder.Services.AddCors(policy => {
    policy.AddPolicy("CorsPolicy",
                 opt => opt.SetIsOriginAllowed(s => true)
                .AllowAnyMethod()
                .AllowAnyHeader());
});
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

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
