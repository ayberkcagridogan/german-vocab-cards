# German Vocab Cards

A flashcard game designed to help users learn German vocabulary. 
Users can add new words, play with existing words, and test their knowledge.

## Features
- Display German words and their English/Turkish translations
- Quiz mode to test your vocabulary (Correct/Wrong)
- Score tracking
- Add and manage words via the backend API

## Technologies
- Frontend: React
- Backend: .NET Web API
- Database: SQLite (initial) or optional SQL Server/PostgreSQL
- GitHub: Project management and version control

## Setup

### Backend
1. Navigate to `backend/GermanCards.Api` folder
2. Restore dependencies using .NET CLI: `dotnet restore`
3. Apply database migration:`dotnet ef migrations add InitialCreate dotnet ef database update`
4. Run the application:`dotnet run`

### FRONDEND
1. Navigate to `frontend` folder
2. Install dependencies:`npm install`
3. Start the application:`npm start`
