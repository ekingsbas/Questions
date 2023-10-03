using Microsoft.AspNetCore.Mvc;
using Questions.BLL.Contracts;
using Questions.Entities.Entities;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("api/questiontags")]
    public class QuestionTagController : ControllerBase
    {
        private readonly IQuestionTagService _questionTagService;

        public QuestionTagController(IQuestionTagService questionTagService)
        {
            _questionTagService = questionTagService;
        }

        /// <summary>
        /// Gets all question tags.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetQuestionTags()
        {
            try
            {
                var questionTags = await _questionTagService.GetAllQuestionTagsAsync();
                return Ok(questionTags);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a question tag by its ID.
        /// </summary>
        /// <param name="id">The ID of the question tag.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionTagById(int id)
        {
            try
            {
                var questionTag = await _questionTagService.GetQuestionTagByIdAsync(id);
                if (questionTag == null)
                {
                    return NotFound();
                }
                return Ok(questionTag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new question tag.
        /// </summary>
        /// <param name="questionTag">The question tag data to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateQuestionTag([FromBody] QuestionTag questionTag)
        {
            try
            {
                if (questionTag == null)
                {
                    return BadRequest("Question tag data is not valid.");
                }

                await _questionTagService.CreateQuestionTagAsync(questionTag);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing question tag.
        /// </summary>
        /// <param name="id">The ID of the question tag.</param>
        /// <param name="questionTag">The updated question tag data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionTag(int id, [FromBody] QuestionTag questionTag)
        {
            try
            {
                if (questionTag == null || id != questionTag.QuestionTagId)
                {
                    return BadRequest("Invalid question tag data.");
                }

                await _questionTagService.UpdateQuestionTagAsync(questionTag);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a question tag by its ID.
        /// </summary>
        /// <param name="id">The ID of the question tag to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionTag(int id)
        {
            try
            {
                await _questionTagService.DeleteQuestionTagAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
