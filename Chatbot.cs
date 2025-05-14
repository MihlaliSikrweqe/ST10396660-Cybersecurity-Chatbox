using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10396660_Cybersecurity_Chatbox
{
    public class Chatbot
    {
        public string UserName { get; set; }
        private string FavoriteTopic = "";
        private Dictionary<string, List<string>> keywordResponses;
        private List<string> phishingTips;
        private List<string> sentiments;

        public Chatbot()
        {
            //Keyword-based responses
            keywordResponses = new Dictionary<string, List<string>>
            {
                {"password", new List<string> {
                    "Use strong passwords with letters, numbers, and symbols.",
                    "Don't reuse passwords across sites.",
                    "Use a password manager to keep track of credentials."
                }},
                {"scam", new List<string> {
                    "Never click unknown links in emails.",
                    "Scammers often pretend to be banks or government officials.",
                    "Verify suspicious calls or emails before responding."
                }},
                {"privacy", new List<string> {
                    "Check app permissions regularly.",
                    "Limit what personal info you share online.",
                    "Use end-to-end encrypted messaging apps."
                }},
                {"phishing", new List<string> {
                    "Don't trust urgent messages asking for sensitive data.",
                    "Verify the sender's email address carefully.",
                    "Look for grammar mistakes in phishing attempts."
                }},
            };

            phishingTips = new List<string>
            {
                "Never give out your login info in response to an email.",
                "Hover over links to check where they lead before clicking.",
                "Report phishing emails to your email provider."
            };

            sentiments = new List<string> { "worried", "curious", "frustrated" };
        }

        public void RespondToUser (string input)
        {
            input = input.ToLower();

            // Detect sentiment
            foreach (string mood in sentiments)
            {
                if (input.Contains(mood))
                {
                    UI.TypeWrite(SentimentResponse(mood));
                    return;
                }
            }

            // Detect favorite topic
            if (input.Contains("interested in"))
            {
                int index = input.IndexOf("interested in") + 13;
                FavoriteTopic = input.Substring(index).Trim();
                UI.TypeWrite($"Thanks! I'll remember that you're interested in {FavoriteTopic}.");
                return;
            }

            // Recall favorite topic
            if (input.Contains("remember") || input.Contains("favorite"))
            {
                if (!string.IsNullOrEmpty(FavoriteTopic))
                    UI.TypeWrite($"You mentioned you're interested in {FavoriteTopic}. Let's talk more about that.");
                else
                    UI.TypeWrite("I don't think you've told me your favorite topic yet.");
                return;
            }

            // Recognize keywords and respond
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    var responses = keywordResponses[keyword];
                    var random = new Random();
                    int index = random.Next(responses.Count);
                    UI.TypeWrite(responses[index]);
                    return;
                }
            }

            // Phishing tip request
            if (input.Contains("phishing tip"))
            {
                var random = new Random();
                int index = random.Next(phishingTips.Count);
                UI.TypeWrite(phishingTips[index]);
                return;
            }

            // Fallback
            UI.TypeWrite("I'm not sure I understand. Could you rephrase or ask something else?");
        }

        private string SentimentResponse(string mood)
        {
            switch (mood)
            {
                case "worried":
                    return "It's okay to feel worried. Cyber threats can be scary, but I’m here to help.";
                case "curious":
                    return "Curiosity is great! Let’s explore some cybersecurity tips together.";
                case "frustrated":
                    return "Sorry you're feeling frustrated. Let me help simplify things for you.";
                default:
                    return "Tell me more about how you're feeling.";
            }
        }
    }
}
