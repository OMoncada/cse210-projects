using System;

namespace Generator 
{
    class QuestionGenerator
    {
        private string[] prompts = {
            "Who did I have the most interesting conversation with today?",
            "What was the predominant emotion in my day?",
            "What was the highlight of my day?",
            "Where could I perceive the positive influence in my life today?",
            "If you had the opportunity to do anything today, what activity would you choose?",
            "What important lesson will you learn today?",
            "What was the most significant challenge I faced today and how did I handle it?",
            "What act of kindness or generosity did I witness or perform today that made me feel good?"
        };

        public string GetRandomPrompt()
        {
            Random rand = new Random();
            int index = rand.Next(prompts.Length);
            return prompts[index];
        }
    }
}
