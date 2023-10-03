using Questions.Entities.Entities;

namespace Questions.BLL.Contracts
{
    public interface IVoteService
    {
        Task<Vote> GetVoteByIdAsync(int voteId);
        Task<IEnumerable<Vote>> GetAllVotesAsync();
        Task CreateVoteAsync(Vote vote);
        Task UpdateVoteAsync(Vote vote);
        Task DeleteVoteAsync(int voteId);
    }
}
