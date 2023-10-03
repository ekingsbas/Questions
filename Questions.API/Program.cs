
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questions.BLL.Contracts;
using Questions.BLL.Services;
using Questions.DAL;
using Questions.DAL.Contracts;
using Questions.DAL.Repositories;

namespace Questions.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json") 
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            // Add services to the container.
            builder.Services.AddDbContext<QuestionsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            builder.Services.AddControllers() ;

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IAnswerService, AnswerService>();
            builder.Services.AddScoped<IQuestionTagService, QuestionTagService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVoteService, VoteService>();
            builder.Services.AddScoped<IBulkImportService, BulkImportService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}