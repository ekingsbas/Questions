using Questions.BLL.Contracts;
using Questions.DAL.Contracts;
using Questions.Entities.Entities;

namespace Questions.BLL.Services
{
    public class QuestionTagService: IQuestionTagService
    {
        private readonly IRepository<QuestionTag> _questionTagRepository;

        public QuestionTagService(IRepository<QuestionTag> questionTagRepository)
        {
            _questionTagRepository = questionTagRepository ?? throw new ArgumentNullException(nameof(questionTagRepository));
        }

        public async Task<QuestionTag> GetQuestionTagByIdAsync(int questionTagId)
        {
            return await _questionTagRepository.GetByIdAsync(questionTagId);
        }

        public async Task<IEnumerable<QuestionTag>> GetAllQuestionTagsAsync()
        {
            return await _questionTagRepository.GetAllAsync();
        }

        public async Task CreateQuestionTagAsync(QuestionTag questionTag)
        {
            await _questionTagRepository.AddAsync(questionTag);
        }

        public async Task UpdateQuestionTagAsync(QuestionTag questionTag)
        {
            await _questionTagRepository.UpdateAsync(questionTag);
        }

        public async Task DeleteQuestionTagAsync(int questionTagId)
        {
            var questionTag = await _questionTagRepository.GetByIdAsync(questionTagId);
            if (questionTag != null)
            {
                await _questionTagRepository.DeleteAsync(questionTag);
            }
        }
    }
}
