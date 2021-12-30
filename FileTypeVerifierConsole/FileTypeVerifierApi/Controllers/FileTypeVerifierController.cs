using Microsoft.AspNetCore.Mvc;
using nClam;

namespace FileTypeVerifierApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileTypeVerifierController : ControllerBase
    {
        private readonly ILogger<FileTypeVerifierController> _logger;
        private readonly IConfiguration _configuration;

        public FileTypeVerifierController(ILogger<FileTypeVerifierController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("single-file")]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            var ftv = new FileTypeVerifierLib.FileTypeVerifier();
            //if ((ftv.IsOfFileType("xlsx", file)) || (ftv.IsOfFileType("xls", file)))
            var fileStream = file.OpenReadStream();
            if ((ftv.IsOfFileType("xlsx", fileStream)) || (ftv.IsOfFileType("xls", fileStream)))
            {
                fileStream.Position = 0;

                var ClamAVServerURL = _configuration["ClamAVServer:URL"];
                var ClamAVServerPORT = Convert.ToInt32(_configuration["ClamAVServer:Port"]);
                //var clam = new ClamClient("http://ip172-18-0-23-c74sge7njsv000929th0-3310.direct.labs.play-with-docker.com/");
                var clam = new ClamClient(ClamAVServerURL,ClamAVServerPORT);
                var scanResult = await clam.SendAndScanFileAsync(fileStream);

                if (scanResult.Result == ClamScanResults.Clean)
                {
                    _logger.LogInformation("The file is clean! ScanResult:{1}", scanResult.RawResult);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest("Invalid File");
        }
    }
}