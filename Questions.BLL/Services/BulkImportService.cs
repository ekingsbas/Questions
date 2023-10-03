using Questions.BLL.Contracts;
using Questions.DAL.Contracts;
using Questions.Entities.Entities;
using Questions.Entities.Models;
using System.Text.Json;

namespace Questions.BLL.Services
{
    public class BulkImportService : IBulkImportService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Answer> _answerRepository;

        public BulkImportService(IRepository<Question> questionRepository, IRepository<Answer> answerRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _answerRepository = answerRepository ?? throw new ArgumentNullException(nameof(answerRepository));
        }

        public async Task ImportJsonAsync(Stream jsonStream)
        {
            try
            {
                using (var streamReader = new StreamReader(jsonStream))
                {
                    var jsonContent = await streamReader.ReadToEndAsync();

                    // Deserialize the JSON content into a model representing the provided structure
                    var importData = JsonSerializer.Deserialize<ImportData>(jsonContent);

                    // Access the 'questions' property to process individual questions and answers
                    foreach (var questionData in importData.Questions)
                    {
                        var question = new Question
                        {
                            Title = questionData.Title,
                            Body = questionData.Content,
                            QuestionTags = questionData.Tags.Select(t => new QuestionTag { TagName = t}).ToList(),
                            UserId= questionData.UserId,
                            CreatedAt = DateTime.Now
                        };

                        // Create the question and obtain its ID
                        await _questionRepository.AddAsync(question);

                        // Process answers associated with the question
                        foreach (var answerData in questionData.Answers)
                        {
                            var answer = new Answer
                            {
                                Body = answerData.Content,
                                UserId = questionData.UserId,
                                CreatedAt= DateTime.Now,
                                QuestionId = question.QuestionId // Assign the ID of the associated question
                            };

                            // Create the answer
                            await _answerRepository.AddAsync(answer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                throw new Exception("Error during bulk import.", ex);
            }
        }
    }
}
