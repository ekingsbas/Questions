using Questions.BLL.Contracts;
using Questions.DAL.Contracts;
using Questions.Entities.Entities;
using System.Linq.Expressions;

namespace Questions.BLL.Services
{
    public class QuestionService: IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IQuestionRepository _questionExtRepository;

        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<QuestionTag> _questionTagRepository;

        public QuestionService(IQuestionRepository questionExtRepository, IRepository<Question> questionRepository, 
                IRepository<Answer> answerRepository, IRepository<QuestionTag> questionTagRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _answerRepository = answerRepository ?? throw new ArgumentNullException(nameof(answerRepository));
            _questionTagRepository = questionTagRepository ?? throw new ArgumentNullException(nameof(questionTagRepository));
            _questionExtRepository = questionExtRepository ?? throw new ArgumentNullException(nameof(questionExtRepository));
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            return await _questionRepository.GetByIdAsync(questionId);
        }

        public async Task<Question> GetQuestionByIdWithDepsAsync(int questionId)
        {
            var question =  await _questionRepository.GetByIdAsync(questionId);
            if (question != null)
            {
                var tags = await _questionTagRepository.GetAllAsync(w => w.QuestionId == questionId);
                question.QuestionTags = tags.ToList();

                var answers = await _answerRepository.GetAllAsync(w => w.QuestionId == questionId);
                question.Answers = answers.ToList();
            }

            return question;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByTagsAsync(List<string> tags)
        {
            // Realiza una consulta en la base de datos para obtener las preguntas por etiquetas
            var questions = await _questionExtRepository.GetQuestionsByTagsAsync(tags);

            return questions;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllAsync();
        }

        public async Task CreateQuestionAsync(Question question)
        {

            await _questionRepository.AddAsync(question);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _questionRepository.UpdateAsync(question);
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question != null)
            {
                await _questionRepository.DeleteAsync(question);
            }
        }
    }
}
