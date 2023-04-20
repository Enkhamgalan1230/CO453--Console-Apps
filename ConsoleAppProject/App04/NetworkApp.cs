using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleAppProject.App04
{
    
    /// <summary>
    /// This class inherits to newsfeed class
    /// this class is responsible for most features of the app
    /// 
    /// </summary>
    public class NetworkApp : NewsFeed
    {

        // CONSTANTS AND ARRAYS DECLARED HERE 
        //
        public static string CurrentUser { get; set; }

        private char input;

        public NewsFeed news = new NewsFeed();

        public int PostCounter { get; set; }

        public const int MaxLength = 69;

        public const int MinLength = 1;

        private bool postNow = false;


        public const string AllowedChars = @"^[0-9a-zA-Z!@#$%&*()_\-+={[}\]|:;'<,>.?~` ]*$";

        // I USED THIS METHOD FOR PROGRAM.CS TO RUN THIS APP
        public void Run()
        {
            DisplayMenu();
        }

        /// <summary>
        /// Menu of choices for a newsfeed app 
        /// The method then enters a do-while loop that repeatedly displays the menu,
        /// prompts the user for input, and executes the user's selected choice
        /// until the user decides to quit.
        /// 
        /// </summary>
        public void DisplayMenu()
        {


            Console.WriteLine("\n===== Enkh-Amgalan Enkhbayar's newsfeed =====");

            string[] choices = new string[]
            {
                "Post Message", "Post Image",
                "Display All Posts", "Display by Author", "Display by Date",
                "Logout", "Quit"
            };

            bool wantToQuit = false;

            Newuser();

            do
            {

                Console.WriteLine("\n ======  Main Menu  ====== ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"-- Logged in as: {CurrentUser} --\n");
                Console.ForegroundColor = ConsoleColor.Green;


                int choice = ConsoleHelper.SelectChoice(choices);

                // executes a switch statement based on the value of "choice".
                // (postnow boolean variable)
                postNow = false;

                switch (choice)
                {
                    case 1: PostMessage(); break;

                    case 2: PostImage(); break;

                    case 3: DisplayAll(); break;

                    case 4:
                        Console.Write("\n Enter author name > ");

                        Search = Console.ReadLine();

                        DisplayByAuthor(Search);

                        break;

                    case 5:
                        Console.Write("\n Enter year > ");

                        Search = Console.ReadLine();

                        DisplayByDate(Search);

                        break;

                    case 6: DisplayMenu(); break;

                    case 7: wantToQuit = true; break;

                    default: break;
                }

            } while (!wantToQuit);
        }

        // Asks for name from user and holds the name in current user variable
        // so i can use it for searching post by author/user
        private void Newuser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n Enter the username :  ");
            Console.ForegroundColor = ConsoleColor.Green;

            CurrentUser = Console.ReadLine();

            news.Author = CurrentUser;
        }

        public void DisplayAll()
        {
            news.Display();
        }

        /// <summary>
        /// This method will allow users to post images
        /// User's two inputs will be held in two Arrays which is 
        /// in Photopost.cs class.
        /// </summary>
        private void PostImage()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n Enter image filename :  ");

            string filename = Console.ReadLine();

            Console.Write("\n Enter image caption :  ");

            string caption = Console.ReadLine();

            PhotoPost photopost = new PhotoPost(CurrentUser, filename, caption);

            news.AddPhotoPost(photopost);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n ===== Image has posted! ====== \n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();
        }
        /// <summary>
        /// In this method User will be able to post a message.
        /// I saw a interesting idea from Sihan which was not just using string
        /// but using Chars and then turning into string. 
        /// So i will be able to calculate maximum characters available.
        /// Everytime when char is entered the counter goes down by one 
        /// however it does right opposite when user press backspace
        /// Also it loops and clears the console because it prints everytime when 
        /// new Char is entered. 
        /// </summary>
        private void PostMessage()
        {
            Console.WriteLine($"\n {MaxLength}/{MaxLength} characters " +
                $"remaining\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" Type your message :  ");
            Console.ForegroundColor = ConsoleColor.Green;

            var message = "";

            int remainingChars = MaxLength;

            // Keep prompting the user until they post their message.
            do
            {
                DetectUserInput();

                // If the user presses the backspace key and the message is longer than the minimum length,
                // remove the last character from the message and increase the remaining characters.
                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Backspace) && message.Length >= MinLength)
                {
                    int lastChar = message.Length - 1;

                    message = message.Remove(lastChar);

                    remainingChars++;
                }
                // If the user types an allowed character, add it to the message and decrease the remaining characters.
                else
                {
                    if (Regex.IsMatch(input.ToString(), AllowedChars))
                    {
                        message += input.ToString();
                        remainingChars--;
                    }
                }
                // If the user presses the enter key and the message is longer than the minimum length, set the postNow to true.

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Enter) && message.Length >= MinLength)
                {
                    postNow = true;
                }

                Console.Clear();

                // Display the number of remaining characters.
                Console.WriteLine($"\n {remainingChars}/{MaxLength} characters " + $"remaining\n");

                // Display the message with the remaining characters.
                Console.Write($" Type your message : {message}");

            } while (postNow == false);

            // Create a new message
            if (message.Length <= MaxLength)
            {
                MessagePost post = new MessagePost(CurrentUser, message);

                news.AddMessagePost(post);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ===== Your message has posted ! =====\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
            }
            // Printing error message if input is more than allowed characters 
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n -- Message must be {MaxLength} characters " + $"or less --\n0)");
                Console.ForegroundColor = ConsoleColor.Green;
                postNow = false;

                PostMessage();
            }
        }
        // Detects user input and returns the key character.
        public char DetectUserInput()
        {
            input = Console.ReadKey().KeyChar;

            return input;
        }

        // PRINTING ALL THE POSTS TO THE NEWSFEED
        //
        private void DisplayResults(int i, Post post)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" -- Showing {i}/{PostCounter} posts --");
            Console.ForegroundColor = ConsoleColor.Green;


            post.Display();

            if (i == PostCounter)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" -- End of the posts -- ");
                Console.ForegroundColor = ConsoleColor.Green;
            }



        }

        /// <summary>
        /// This method takes in an author's name as a parameter and displays all posts made by that author.
        /// </summary>
        /// <param name="author"></param>
        public void DisplayByAuthor(String author)
        {
            // If there is no posts to show, shows error message
            if (news.Posts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" ===== No posts to show ====== \n");
                Console.ForegroundColor = ConsoleColor.Green;
                //Console.Clear();
            }

                // If there are posts, initialize a counter for the number of posts made by the author
                // Iterate through all posts in the list and increment the counter if the author matches
            else
            {
                PostCounter = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Username.ToString() == author)
                    {
                        PostCounter++;
                    }
                }
                // If the counter is greater than zero, display all posts made by the author
                if (PostCounter > 0)
                {
                    int i = 0;

                    foreach (Post post in news.Posts.ToList())
                    {
                        if (post.Username.ToString() == author)
                        {
                            i++;

                            DisplayResults(i, post);
                        }
                    }
                }
                // If counter is zero, display error message
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" ===== Can't find any posts ====== \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Clear();
                }
            }
        }

        /// <summary>
        /// This method takes in an date as a parameter and displays all posts made during that period
        /// And do same proccess as the find by author method does 
        /// </summary>
        /// <param name="date"></param>
        public void DisplayByDate(String date)
        {
            // check if there are any posts
            if (news.Posts.Count == 0)
            {
                Console.Write(" ===== No posts to show ====== \n");

            }

            else
            {
                PostCounter = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Timestamp.Year.ToString() == date)
                    {
                        PostCounter++;
                    }
                }

                if (PostCounter > 0)
                {
                    int i = 0;

                    foreach (Post post in news.Posts.ToList())
                    {
                        if (post.Timestamp.Year.ToString() == date)
                        {
                            i++;
                            DisplayResults(i, post);
                        }
                    }
                }

                else
                {
                    Console.Write(" ===== Can't find any posts ====== \n");

                    //Console.Clear();
                }
            }
        }



    }
}
