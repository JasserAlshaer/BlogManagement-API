using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BlogManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<string> ConvertImageToBase64(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }
            using (var memory = new MemoryStream())
            {
                //load file to memory
                await file.CopyToAsync(memory);
                //get the bytes [] 
                var bytes = memory.ToArray();
                string baseType = "data:image/webp;base64,";
                return baseType + "" + Convert.ToBase64String(bytes);
            }
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImageAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }
            string newFileURL = DateTime.Now.ToString()+""+file.FileName;
            string newFileURL2 =  Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL2), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL2;
        }
        [HttpGet("{fileName}")]
        public IActionResult GetFile(string fileName)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is not provided");
            }

            var filePath = Path.Combine(uploadFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var contentType = GetContentType(filePath);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, contentType, fileName);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
