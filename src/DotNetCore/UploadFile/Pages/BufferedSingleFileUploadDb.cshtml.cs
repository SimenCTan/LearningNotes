using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using UploadFile.Data;
using Microsoft.AspNetCore.Http;
using UploadFile.Utilities;
using UploadFile.Models;

namespace UploadFile.Pages
{
    public class BufferedSingleFileUploadDbModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt" };
        public BufferedSingleFileUploadDbModel(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _fileSizeLimit = configuration.GetValue<long>("FileSizeLimit");
        }

        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }

        public string Result { get; private set; }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            var formFileContent = await FileHelpers.ProcessFormFile<BufferedSingleFileUploadDb>(FileUpload.FormFile, ModelState, _permittedExtensions, _fileSizeLimit);
            // Perform a second check to catch ProcessFormFile method
            // violations. If any validation check fails, return to the
            // page.
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.
            var file = new AppFile
            {
                Content = formFileContent,
                UntrustedName = FileUpload.FormFile.FileName,
                Note = FileUpload.Note,
                Size = FileUpload.FormFile.Length,
                UploadDT = DateTime.UtcNow
            };
            _appDbContext.AppFiles.Add(file);
            await _appDbContext.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }

    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }

        [Display(Name ="Note")]
        [StringLength(50,MinimumLength =0)]
        public string Note { get; set; }
    }
}
