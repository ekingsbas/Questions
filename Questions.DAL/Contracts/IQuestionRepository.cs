using Questions.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.DAL.Contracts
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsByTagsAsync(List<string> tags);
    }
}
