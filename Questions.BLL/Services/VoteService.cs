using Questions.BLL.Contracts;
using Questions.DAL.Contracts;
using Questions.Entities.Entities;

namespace Questions.BLL.Services
{
    public class VoteService: IVoteService
    {
        private readonly IRepository<Vote> _voteRepository;

        public VoteService(IRepository<Vote> voteRepository)
        {
            _voteRepository = voteRepository ?? throw new ArgumentNullException(nameof(voteRepository));
        }

        public async Task<Vote> GetVoteByIdAsync(int voteId)
        {
            return await _voteRepository.GetByIdAsync(voteId);
        }

        public async Task<IEnumerable<Vote>> GetAllVotesAsync()
        {
            return await _voteRepository.GetAllAsync();
        }

        public async Task CreateVoteAsync(Vote vote)
        {
            await _voteRepository.AddAsync(vote);
        }

        public async Task UpdateVoteAsync(Vote vote)
        {
            await _voteRepository.UpdateAsync(vote);
        }

        public async Task DeleteVoteAsync(int voteId)
        {
            var vote = await _voteRepository.GetByIdAsync(voteId);
            if (vote != null)
            {
                await _voteRepository.DeleteAsync(vote);
            }
        }
    }
}
