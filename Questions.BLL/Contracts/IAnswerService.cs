using Questions.Entities.Entities;

namespace Questions.BLL.Contracts
{
    public interface IAnswerService
    {
        Task<Answer> GetAnswerByIdAsync(int answerId);
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task CreateAnswerAsync(Answer answer);
        Task UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int answerId);
    }
}
