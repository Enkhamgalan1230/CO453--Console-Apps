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
        public const int MaxLength = 69;

        public const int MinLength = 1;

        private char input;

        public const string AllowedChars = @"^[0-9a-zA-Z!@#$%&*()_\-+={[}\]|:;'<,>.?~` ]*$"; 

        private bool postNow = false;

        public void Run()
        {
            DisplayMenu();
        }

        private NewsFeed news = new NewsFeed();

        public int SearchPosts { get; private set; }

        public void DisplayMenu()
        {
            Console.WriteLine(" Entwan's News feed");

            string[] choices = new string[]
            {
                "Post Message", "Post Image",
                "Display All Posts", "Display by Author", "Display by Date",
                "See Menu", "Quit"
            };

            bool wantToQuit = false;
            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);
                
                switch (choice)
                {
                    case 1: PostLimitedMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4:
                        Console.Write(" Enter author name:  ");
                        Search = Console.ReadLine();
                        DisplayByAuthor(Search);
                        break;

                    case 5:
                        Console.Write(" Enter the year:  ");
                        Search = Console.ReadLine();
                        DisplayByDate(Search);
                        break;

                    case 6: DisplayMenu(); break;
                    case 7: wantToQuit = true; break;
                    default: break;

                }
            } while (wantToQuit);   
        }

        private void DisplayAll()
        {
            news.Display();
        }

        private void PostImage()
        {
            Console.WriteLine("Enter image file name : ");
            string filename = Console.ReadLine();

            Console.WriteLine("Enter caption for the image : ");
            string caption = Console.ReadLine();

            PhotoPost photoPost = new PhotoPost("Entwan", filename, caption); 
            news.AddPhotoPost(photoPost);

            Console.WriteLine();
            Console.WriteLine(" Image has posted! ");

            Console.Clear();                                                                                                       
        }

        private void PostLimitedMessage()
        {
            Console.WriteLine($"    {MaxLength}/{MaxLength} characters " + $"remaining  ");

            Console.Write($" Type your message > ");

            var message = "";

            int remainingChars = MaxLength;

            do
            {
               
                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Backspace) &&
                    message.Length >= MinLength)
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

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Enter) &&
                    message.Length >= MinLength)
                {
                    postNow = true;
                }

                Console.Clear();
                Console.WriteLine($"\n {remainingChars}/{MaxLength} characters " +
                    $"remaining\n");

                Console.Write($" Type your message > {message}");

            } while (postNow == false);

            if (message.Length <= MaxLength)
            {
                MessagePost post = new MessagePost("Entwan", message);

                news.AddMessagePost(post);

                Console.WriteLine();
                Console.WriteLine(" Message has posted! ");
                Console.Clear();
            }

            else
            {
                Console.WriteLine($" Message should be Max {MaxLength} characters in total");
                postNow = false;
                PostLimitedMessage();
            }
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
                Console.WriteLine("There is no posts available. ");

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
                    Console.WriteLine("No posts. ");

                    Console.Clear();
                }
            }
        }


        public void DisplayByDate(String date)
        {
            if (news.Posts.Count == 0)
            {
                Console.WriteLine("\n    -- No posts to display --\n");

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
                    Console.WriteLine(" -- No posts found -- ");
                    Console.Clear();
                }
            }
        }



    }
}
