using Questions.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.BLL.Contracts
{
    public interface IQuestionService
    {
        Task<Question> GetQuestionByIdAsync(int questionId);
        Task<Question> GetQuestionByIdWithDepsAsync(int questionId);

        Task<IEnumerable<Question>> GetQuestionsByTagsAsync(List<string> tags);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task CreateQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int questionId);
    }
}
