using Microsoft.EntityFrameworkCore;
using Questions.DAL.Contracts;
using Questions.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.DAL.Repositories
{
    public class QuestionRepository: Repository<Question>, IQuestionRepository
    {
        private readonly QuestionsDbContext _context;
        public QuestionRepository(QuestionsDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Question>> GetQuestionsByTagsAsync(List<string> tags)
        {
            var query = _context.Set<Question>()
            .Where(q => q.QuestionTags.Any(t => tags.Contains(t.TagName)))
            .Include(q => q.Answers)
            .Include(q => q.QuestionTags);

            return await query.ToListAsync();
        }
    }
}
