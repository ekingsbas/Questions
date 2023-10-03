using Questions.BLL.Contracts;
using Questions.DAL.Contracts;
using Questions.Entities.Entities;

namespace Questions.BLL.Services
{
    public class AnswerService: IAnswerService
    {
        private readonly IRepository<Answer> _answerRepository;

        public AnswerService(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository ?? throw new ArgumentNullException(nameof(answerRepository));
        }

        public async Task<Answer> GetAnswerByIdAsync(int answerId)
        {
            return await _answerRepository.GetByIdAsync(answerId);
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            return await _answerRepository.GetAllAsync();
        }

        public async Task CreateAnswerAsync(Answer answer)
        {
            await _answerRepository.AddAsync(answer);
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            await _answerRepository.UpdateAsync(answer);
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            var answer = await _answerRepository.GetByIdAsync(answerId);
            if (answer != null)
            {
                await _answerRepository.DeleteAsync(answer);
            }
        }
    }
}
