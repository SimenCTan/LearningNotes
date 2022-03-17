using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using FileUpload.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs.Models;

namespace FileUpload.Controllers;

[ApiController]
[Route("api/[Controller]/[action]")]
public class FileController : Controller
{
    private readonly BlobContainerClient blobContainerClient;
    private readonly ILogger<FileController> logger;
    private readonly AzureStorageOption storageOption;

    public FileController(BlobContainerClient blobContainerClient,
        ILogger<FileController> logger,
        IOptionsMonitor<AzureStorageOption> optionsMonitor)
    {
        this.blobContainerClient = blobContainerClient;
        this.logger = logger;
        storageOption = optionsMonitor.CurrentValue;
    }

    [HttpPost]
    [ActionName("UploadFile")]
    public async Task<IActionResult> UploadFile()
    {
        var formCollection = await Request.ReadFormAsync();
        var file = formCollection.Files.First();
        if (file.Length <= 0) return BadRequest();
        if (!storageOption.Format.Contains(Path.GetExtension(file.FileName).TrimStart('.'),StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest();
        }

        try
        {
            var blobFile = blobContainerClient.GetBlobClient(file.FileName);
            await blobFile.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            using var fileStream = file.OpenReadStream();
            await blobFile.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
            return Ok(blobFile.Uri.ToString());
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
}

