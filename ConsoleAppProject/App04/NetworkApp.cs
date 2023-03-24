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
    public class NetworkApp : NewsFeed 
    {
        public static string CurrentUser { get; set; }

        private char input;

        public NewsFeed news = new NewsFeed();

        public int SearchPosts { get; set; }

        public const int MaxLength = 50;

        public const int MinLength = 1;

        private bool postNow = false;


        public const string AllowedChars = @"^[0-9a-zA-Z!@#$%&*()_\-+={[}\]|:;'<,>.?~` ]*$";

        
        public void Run()
        {
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            

            Console.WriteLine("===== Enkh-Amgalan Enkhbayar's newsfeed =====");

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

                Console.WriteLine(" ======  Main Menu  ====== ");

                Console.WriteLine($"-- Logged in as: {CurrentUser} --\n");

                

                int choice = ConsoleHelper.SelectChoice(choices);

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

        private void Newuser()
        {
            Console.Write("\n Enter username > ");

            CurrentUser = Console.ReadLine();

            news.Author = CurrentUser;
        }

        public void DisplayAll()
        {
            news.Display();
        }

        private void PostImage()
        {
            Console.Write("\n Enter image filename :  ");

            string filename = Console.ReadLine();

            Console.Write("\n Enter image caption :  ");

            string caption = Console.ReadLine();

            PhotoPost photopost = new PhotoPost(CurrentUser, filename, caption);

            news.AddPhotoPost(photopost);

            Console.Write(" ===== Image has posted! ====== \n");

            Console.Clear();
        }

        private void PostMessage()
        {
            Console.WriteLine($"\n {MaxLength}/{MaxLength} characters " +
                $"remaining\n");


            Console.Write($" Type your message > ");

            var message = "";

            int remainingChars = MaxLength;

            do
            {
                DetectUserInput();

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Backspace) && message.Length >= MinLength)
                {
                    int lastChar = message.Length - 1;

                    message = message.Remove(lastChar);

                    remainingChars++;
                }

                else
                {
                    if (Regex.IsMatch(input.ToString(), AllowedChars))
                    {
                        message += input.ToString();
                        remainingChars--;
                    }
                }

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Enter) &&  message.Length >= MinLength)
                {
                    postNow = true;
                }

                Console.Clear();


                Console.WriteLine($"\n {remainingChars}/{MaxLength} characters " + $"remaining\n");

                Console.Write($" Type your message : {message}");

            } while (postNow == false);

            if (message.Length <= MaxLength)
            {
                MessagePost post = new MessagePost(CurrentUser, message);

                news.AddMessagePost(post);

                Console.WriteLine();

                Console.WriteLine( " ===== Your message has posted ! =====\n");

                Console.Clear();
            }

            else
            {


                Console.WriteLine($"\n -- Message must be {MaxLength} characters " + $"or less --\n0)");

                postNow = false;

                PostMessage();
            }
        }

        public char DetectUserInput()
        {
            input = Console.ReadKey().KeyChar;

            return input;
        }

        private void DisplayResults(int i, Post post)
        {
           

            Console.WriteLine($" -- Showing {i}/{SearchPosts} posts --");

            

            post.Display();

            if (i == SearchPosts)
            {
                Console.WriteLine(" -- End of the posts -- ");
            }

            

        }

        public void DisplayByAuthor(String author)
        {
            if (news.Posts.Count == 0)
            {
                Console.Write(" ===== No posts to show ====== \n");

                Console.Clear();
            }

            else
            {
                SearchPosts = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Username.ToString() == author)
                    {
                        SearchPosts++;
                    }
                }

                if (SearchPosts > 0)
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

                else
                {
                    Console.Write(" ===== Can't find any posts ====== \n");

                    Console.Clear();
                }
            }
        }


        public void DisplayByDate(String date)
        {
            if (news.Posts.Count == 0)
            {
                Console.Write(" ===== No posts to show ====== \n");

            }

            else
            {
                SearchPosts = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Timestamp.Year.ToString() == date)
                    {
                        SearchPosts++;
                    }
                }

                if (SearchPosts > 0)
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

                    Console.Clear();
                }
            }
        }



    }
}
