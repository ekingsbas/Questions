using Microsoft.AspNetCore.Mvc;
using Questions.BLL.Contracts;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("api/bulkimport")]
    public class BulkImportController : ControllerBase
    {
        private readonly IBulkImportService _bulkImportService;

        public BulkImportController(IBulkImportService bulkImportService)
        {
            _bulkImportService = bulkImportService ?? throw new ArgumentNullException(nameof(bulkImportService));
        }

        [HttpPost]
        public async Task<IActionResult> BulkImportJson(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0; // Reset the stream position to the beginning
                    await _bulkImportService.ImportJsonAsync(stream);
                }

                return Ok("JSON data imported successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
