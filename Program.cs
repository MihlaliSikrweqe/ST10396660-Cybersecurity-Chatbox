using System;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST10396660_Cybersecurity_Chatbox;

namespace CybersecurityAwarenessChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot";
            UI.DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;

            UI.TypeWrite("Hello! Welcome to the CS Cybersecurity Awareness ChatBot.");
            UI.TypeWrite("I'm here to help you stay safe online!");

            Chatbot chatbot = new Chatbot();

            Console.Write("\nWhat's your name? ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Please enter a valid name: ");
                name = Console.ReadLine();
            }

            chatbot.UserName = name;
            UI.TypeWrite($"Welcome, {name}! Ask me anything about cybersecurity.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n> ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.TypeWrite("I didn't catch that. Could you try again?");
                    continue;
                }

                if (input.ToLower().Contains("exit") || input.ToLower().Contains("bye"))
                {
                    UI.TypeWrite("Goodbye! Stay safe online.");
                    break;
                }

                chatbot.RespondToUser(input); // Part 2
            }

            // Play voice greeting
            Speak("Hello! Welcome to the CS Cybersecurity Awareness ChatBot. I'm here to help you stay safe online!");

            // Call method to display ASCII logo
            DisplayAsciiArt();

            // Call method for user interaction
            InteractWithUser();
        }

        static void Speak(string message)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak(message);

        }

        // Display Ascii Logo
        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ____ ____     ____ _           _   _                
 / ___/ ___|   / ___| |__   __ _| |_| |__   _____  __ 
| |   \___ \  | |   | '_ \ / _` | __| '_ \ / _ \ \/ / 
| |___ ___) | | |___| | | | (_| | |_| |_) | (_) >  <  
 \____|____/   \____|_| |_|\__,_|\__|_.__/ \___/_/\_\ ");
            Console.ResetColor();
        }

        //Implement User Interaction 
        static void InteractWithUser()
        {
            Console.Write("\nPlease enter your name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You didn't enter a name. Let's try again.");
                InteractWithUser(); // Retry input
            }
            else
            {
                Console.WriteLine($"Hello, {name}! How can I assist you with cybersecurity today?");
                HandleUserQueries();
            }
        }

        // Basic Response System
        static void HandleUserQueries()
        {
            Console.WriteLine("\nAsk me a question (type 'exit' to quit): ");
            string question = Console.ReadLine().ToLower().Trim();

            if (question == "exit")
            {
                Console.WriteLine("Goodbye! Stay safe online.");
                Console.WriteLine("");
            }
            else if (question.Contains("how are you?"))
            {
                Console.WriteLine("I'm just a chatbot, but I'm here to help!");
            }
            else if (question.Contains("What's your purpose?"))
            {
                Console.WriteLine("I educate users about cybersecurity threats and safe online practices.");
            }
            else if (question.Contains("password safety?"))
            {
                Console.WriteLine("Use strong passwords with at least 12 characters, including symbols, numbers, and upper/lowercase letters.");
            }
            else if (question.Contains("phishing?"))
            {
                Console.WriteLine("Be cautious of emails asking for personal details. Verify sender addresses and avoid clicking unknown links.");
            }
            else
            {
                Console.WriteLine("I didn't quite understand that. Could you rephrase?");
            }
        }

        //Input Validation
        static string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        // Enhanced Console UI
        static void TypeEffect(string message, int delay = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

    }
        
}

