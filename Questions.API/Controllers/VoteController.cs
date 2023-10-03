using Microsoft.AspNetCore.Mvc;
using Questions.BLL.Contracts;
using Questions.Entities.Entities;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("api/votes")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        /// <summary>
        /// Gets all votes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetVotes()
        {
            try
            {
                var votes = await _voteService.GetAllVotesAsync();
                return Ok(votes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a vote by its ID.
        /// </summary>
        /// <param name="id">The ID of the vote.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoteById(int id)
        {
            try
            {
                var vote = await _voteService.GetVoteByIdAsync(id);
                if (vote == null)
                {
                    return NotFound();
                }
                return Ok(vote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new vote.
        /// </summary>
        /// <param name="vote">The vote data to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateVote([FromBody] Vote vote)
        {
            try
            {
                if (vote == null)
                {
                    return BadRequest("Vote data is not valid.");
                }

                await _voteService.CreateVoteAsync(vote);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing vote.
        /// </summary>
        /// <param name="id">The ID of the vote.</param>
        /// <param name="vote">The updated vote data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVote(int id, [FromBody] Vote vote)
        {
            try
            {
                if (vote == null || id != vote.VoteId)
                {
                    return BadRequest("Invalid vote data.");
                }

                await _voteService.UpdateVoteAsync(vote);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a vote by its ID.
        /// </summary>
        /// <param name="id">The ID of the vote to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote(int id)
        {
            try
            {
                await _voteService.DeleteVoteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
