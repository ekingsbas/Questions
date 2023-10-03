using Microsoft.AspNetCore.Mvc;
using Questions.BLL.Contracts;
using Questions.Entities.Entities;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            try
            {
                var questions = await _questionService.GetAllQuestionsAsync();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a question by its ID.
        /// </summary>
        /// <param name="id">The ID of the question.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            try
            {
                //var question = await _questionService.GetQuestionByIdAsync(id);
                var question = await _questionService.GetQuestionByIdWithDepsAsync(id);

                if (question == null)
                {
                    return NotFound();
                }
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get questions by tags
        /// </summary>
        /// <param name="tags"></param>
        [HttpGet("bytags")]
        public async Task<IActionResult> GetQuestionsByTags([FromQuery] List<string> tags)
        {
            try
            {
                // Filtering
                var questions = await _questionService.GetQuestionsByTagsAsync(tags);

                if (questions == null || !questions.Any())
                {
                    return NotFound("No questions found with specified tags");
                }

                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new question.
        /// </summary>
        /// <param name="question">The question data to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] Question question)
        {
            try
            {
                if (question == null)
                {
                    return BadRequest("Question data is not valid.");
                }

                await _questionService.CreateQuestionAsync(question);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing question.
        /// </summary>
        /// <param name="id">The ID of the question.</param>
        /// <param name="question">The updated question data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] Question question)
        {
            try
            {
                if (question == null || id != question.QuestionId)
                {
                    return BadRequest("Invalid question data.");
                }

                await _questionService.UpdateQuestionAsync(question);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a question by its ID.
        /// </summary>
        /// <param name="id">The ID of the question to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                await _questionService.DeleteQuestionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
