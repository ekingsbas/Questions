using Questions.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.BLL.Contracts
{
    public interface IQuestionTagService
    {
        Task<QuestionTag> GetQuestionTagByIdAsync(int questionTagId);
        Task<IEnumerable<QuestionTag>> GetAllQuestionTagsAsync();
        Task CreateQuestionTagAsync(QuestionTag questionTag);
        Task UpdateQuestionTagAsync(QuestionTag questionTag);
        Task DeleteQuestionTagAsync(int questionTagId);
    }
}
