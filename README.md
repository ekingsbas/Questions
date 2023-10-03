# Question-Answering Application

This is the backend API for a question-answering application developed using C#. It includes functionality for users to ask questions, provide answers, and optionally vote on both questions and answers. Users can also filter questions by tags.

## Table of Contents
- [Database Design](#database-design)
- [Bulk Import Logic](#bulk-import-logic)
- [RESTful API](#restful-api)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Database Design
- The database schema was designed using Entity Framework (EF) Code First.
- Entities:
  - User
  - Question
  - Answer
  - QuestionTag
  - (Optional) Vote

## Bulk Import Logic
- Developed bulk import logic to facilitate the addition of questions and answers.
- The application supports importing data from a JSON file.
- The API project includes a Json file as an example for this porpuse (bulkimport.json).

## RESTful API
- The API provides endpoints for various actions, including:
  - Posting new questions with specified tags.
  - Posting answers to existing questions.
  - (Optional) Voting on questions and answers.
  - Querying questions by tags.
  - Retrieving question details along with answers.

## Usage
- Clone the repository.
- Set up the database using Entity Framework migrations.
- Run the application.

## API Documentation
- The API is documented using Swagger. You can access the documentation by running the application and visiting the `/swagger` endpoint.

## Contributing
- Contributions are welcome! Feel free to open issues or submit pull requests.

## License
- This project is licensed under the [MIT License](LICENSE).
