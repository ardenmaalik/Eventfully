using Eventfully.Application.AWS.S3.Interfaces;
using Eventfully.Application.AWS.S3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventfully.WebUI.AWS.S3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadFileController : ControllerBase
    {
        private string _dir;
        private readonly IStorageService _storageService;
        public UploadFileController(IWebHostEnvironment env, IStorageService storageService)
        {
            _storageService = storageService;
            _dir = env.WebRootPath;
        }

        [HttpPost(Name = "UploadVideo")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var appSettings = System.Configuration.ConfigurationManager.AppSettings;

            // process file
            await using var fileStr = new FileStream(Path.Combine(_dir, "file.mp4"), FileMode.Create, FileAccess.Write);
            
            await file.CopyToAsync(fileStr);
            
            // don't need
            var fileExt = Path.GetExtension(file.Name);
            var objName = $"{Guid.NewGuid()}.{fileExt}";

            var s3Obj = new S3Object()
            {
                BucketName = "eventfully-demo-am-1",
                InputStream = fileStr,
                Name = objName
            };

            var cred = new AwsCredentials()
            {
                AwsKey = appSettings["AwsAccessKey"],
                AwsSecret = appSettings["AwsSecret"]
            };

            var result = await _storageService.UploadFileAsync(s3Obj, cred);

            return Ok(result);
        }
    }
}
