using Microsoft.AspNetCore.Mvc;
using Questions.BLL.Contracts;
using Questions.Entities.Entities;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("api/answers")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        /// <summary>
        /// Gets all answers.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAnswers()
        {
            try
            {
                var answers = await _answerService.GetAllAnswersAsync();
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets an answer by its ID.
        /// </summary>
        /// <param name="id">The ID of the answer.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            try
            {
                var answer = await _answerService.GetAnswerByIdAsync(id);
                if (answer == null)
                {
                    return NotFound();
                }
                return Ok(answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new answer.
        /// </summary>
        /// <param name="answer">The answer data to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] Answer answer)
        {
            try
            {
                if (answer == null)
                {
                    return BadRequest("Answer data is not valid.");
                }

                await _answerService.CreateAnswerAsync(answer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing answer.
        /// </summary>
        /// <param name="id">The ID of the answer.</param>
        /// <param name="answer">The updated answer data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, [FromBody] Answer answer)
        {
            try
            {
                if (answer == null || id != answer.AnswerId)
                {
                    return BadRequest("Invalid answer data.");
                }

                await _answerService.UpdateAnswerAsync(answer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an answer by its ID.
        /// </summary>
        /// <param name="id">The ID of the answer to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                await _answerService.DeleteAnswerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
