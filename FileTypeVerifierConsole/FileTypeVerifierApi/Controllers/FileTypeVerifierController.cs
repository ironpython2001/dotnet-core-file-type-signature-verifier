using Microsoft.AspNetCore.Mvc;

namespace FileTypeVerifierApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileTypeVerifierController : ControllerBase
    {
        private readonly ILogger<FileTypeVerifierController> _logger;

        public FileTypeVerifierController(ILogger<FileTypeVerifierController> logger)
        {
            _logger = logger;
        }

        [HttpPost("single-file")]
        public ActionResult Upload(IFormFile file)
        {
            var ftv = new FileTypeVerifierLib.FileTypeVerifier();
            if (ftv.IsOfFileType("xlsx", file))
                return Ok();
            else
                return BadRequest("Invalid File");
        }
    }
}