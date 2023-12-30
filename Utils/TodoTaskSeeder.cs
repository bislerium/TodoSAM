using TodoSAM.Models;

namespace TodoSAM.Utils
{
    internal static class TodoTaskSeeder
    {
        private static readonly string[] _tasks = {
            "Complete project proposal",
            "Call John to discuss upcoming meeting",
            "Buy groceries for the week",
            "Send birthday wishes to mom",
            "Schedule dentist appointment",
            "Finish reading chapter 5 of the book",
            "Attend team meeting at 2:00 PM",
            "Pay utility bills",
            "Organize desk and declutter",
            "Plan weekend getaway",
            "Review and update resume",
            "Date with Bislerium at 8PM NPT",
            "Research new workout routines",
            "Set up a meeting with the marketing team",
            "Water the plants",
            "Respond to client emails",
            "Create a shopping list for home office supplies",
            "Practice meditation for 15 minutes",
            "Write a blog post for personal website",
            "Investigate online courses for professional development",
            "Check and respond to social media messages"
        };

        private static bool GetRandomBool() => Random.Shared.Next(2) == 0;


        internal static List<TodoTask> Seed() => _tasks
            .Select(t => new TodoTask() 
            { 
                Task = t,
                IsCompleted = GetRandomBool(),
                IsImportant = GetRandomBool(),
            })
            .ToList();
    }
}
