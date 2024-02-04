public class QuestionGenerator
    {
        public string GenerateQuestion()
        {
            var questions = new List<string> {"What was the best part of your day?", "Did you serve anyone today or did anyone serve you?",
            "What did you eat today?", "Who are you grateful for today?", "What was your song of the day?"};
            int count = questions.Count;
            var r = new Random();
            int list_index = r.Next(count);
            string _question = questions[list_index];
            return _question;
        }
    }