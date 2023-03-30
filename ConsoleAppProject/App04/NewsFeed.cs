using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        // Declaring constants and arrays
        //
        public List<int> Likes;

        public string Author;
        public bool StopLoop { get; set; }

        public bool NoPosts = false;

        public int AvailablePosts { get; set; }

        public int AvailablePostsCounter { get; set; }

        public List<Post> Posts { get; set; }
        public string Search { get; set; }  

        public const string Empty = "";

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            Posts = new List<Post>();

            Likes = new List<int>();

        
        }

        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            Posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            Posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            if (Posts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  No posts to display   ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Clear();
            }
            else
            {
                LoopDisplay();
            }
            
        }
        /// <summary>
        /// // This method loops through the available posts, displays them, and allows the user to interact.
        /// </summary>
        private void LoopDisplay()
        {
            if (Posts.Count == 0)
            {
                AvailablePostsCounter = 0;
            }

            else
            {
                // Loop through all available posts
                for (AvailablePostsCounter = 0; AvailablePostsCounter <= Posts.Count; AvailablePostsCounter++)
                {
                    StopLoop = false;

                    

                    // Display the final post again if the user is at the end of the list
                    RepeatFinalPost();

                    // Display the current post
                    if (AvailablePosts < Posts.Count - 1)
                    {
                        ShowPost();
                    }

                    Console.WriteLine();

                    // Show a list of options and allow the user to choose
                    string[] choices = new string[]
                    {
                      " Like \n",
                      " Unlike \n",
                      " Remove this post \n",
                      " Remove all posts \n",
                      " Comment on this post \n",
                      " Next post \n",
                      " Main Menu \n"
                    };

                    int choice = ConsoleHelper.SelectChoice(choices);

                    switch (choice)
                    {
                        case 1:
                            LikePost(Posts[AvailablePostsCounter]);

                            AvailablePostsCounter--;

                            break;

                        case 2:
                            UnlikePost(Posts[AvailablePostsCounter]);

                            AvailablePostsCounter--;

                            break;

                        case 3:
                            RemovePost();

                            AvailablePostsCounter--;

                            break;

                        case 4:
                            RemoveAllPosts();

                            break;

                        case 5:
                            AddComment(Posts[AvailablePostsCounter]);

                            AvailablePostsCounter--;

                            break;

                        case 6:
                            ShowNextPost();

                            break;

                        case 7:
                            Console.Clear();

                            StopLoop = true;

                            break;

                        default:
                            break;
                    }

                    // If the user has removed all posts, exit the loop
                    if (StopLoop && NoPosts)
                    {
                        AvailablePosts = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n ===== All posts removed =====\n");
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine();

                        break;
                    }
                    // If the user has returned to the main menu, exit the loop
                    else

                    {
                        if (StopLoop)
                        {
                            AvailablePosts = 0;

                            Console.WriteLine();

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Showing avaiable posts.
        /// </summary>
        private void ShowPost()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n   ==== Showing {AvailablePosts + 1}/" +  $"{Posts.Count} posts ====");
            Console.ForegroundColor = ConsoleColor.Green;
            Posts[AvailablePostsCounter].Display();
        }
        /// <summary>
        /// // This method shows the last post in the list
        /// </summary>

        private void ShowLastPost()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n   ==== Showing {AvailablePosts + 1}/" + $"{Posts.Count} posts ====");
            Console.ForegroundColor = ConsoleColor.Green;
            Posts[AvailablePosts].Display();
        }

        /// <summary>
        /// This method is called when the user reaches 
        /// the end of the post list and wants to see the last post again
        /// </summary>
        private void RepeatFinalPost()
        {
            if (AvailablePostsCounter == Posts.Count - 1)
            {
                AvailablePosts = Posts.Count - 1;

                AvailablePostsCounter = AvailablePosts - 1;

                ShowLastPost();

                AvailablePostsCounter++;
            }
        }
        /// <summary>
        /// This method is called when the user wants to see the next post in the list
        /// </summary>
        public void ShowNextPost()
        {
            if (AvailablePostsCounter < Posts.Count - 1)
            {
                AvailablePosts++;
            }
            else
            {
                AvailablePostsCounter--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n ==== No posts to display ! ====\n");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        /// <summary>
        /// This method adds a comment to a post
        /// </summary>
        /// <param name="post"></param>
        public static void AddComment(Post post)
        {
            Console.Write("\n    Enter comment :  ");

            string text = Console.ReadLine();

            post.AddComment(text);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n    -- Comment added --\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        /// <summary>
        /// This method is called when the user likes a post
        /// </summary>
        /// <param name="post"></param>
        private void LikePost(Post post)
        {
            // If the user is trying to like their own post, display an error message
            if (Posts[AvailablePostsCounter].Username == NetworkApp.CurrentUser)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n ===== You can't like your own posts ====== \n");
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else
            {
                if (!Likes.Contains(AvailablePostsCounter))
                {
                    post.Like();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n ===== You liked this post ====== \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Likes.Add(AvailablePostsCounter);
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n ===== You've liked this post already ====== \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }

        }
        /// <summary>
        /// This method is called when the user unlikes a post
        /// </summary>
        /// <param name="post"></param>
        private void UnlikePost(Post post)
        {
            if (Posts[AvailablePostsCounter].Username == NetworkApp.CurrentUser)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n ===== You cannot like your own posts  ====== \n");
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else
            {
                if (Likes.Contains(AvailablePostsCounter))
                {
                    post.Unlike();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n ===== You unliked this post ====== \n");
                    Console.ForegroundColor = ConsoleColor.Green;

                    int like = Likes.FindIndex(x => x == AvailablePostsCounter);

                    Likes.RemoveAt(like);
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n ===== You didn't like this post ====== \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        /// <summary>
        /// This method removes all posts from the Posts list and sets StopLoop to true.
        /// </summary>
        private void RemoveAllPosts()
        {
            Posts = new List<Post>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ==== All posts removed ==== \n");
            Console.ForegroundColor = ConsoleColor.Green;


            StopLoop = true;
        }
        /// <summary>
        /// This method removes a post from the Posts list if it belongs to the current user.
        /// If the post does not belong to the current user, it displays an error message.
        /// If there is only one post left after removing, it calls RemoveAllPosts().
        /// </summary>
        private void RemovePost()
        {
            if (Posts[AvailablePostsCounter].Username == NetworkApp.CurrentUser)
            {
                Posts.RemoveAt(AvailablePostsCounter);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n ===== Post removed ====== \n");
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else
            {
                if (Posts.Count == 1)
                {
                    RemoveAllPosts();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n ===== Only the user can remove this post ====== \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }

        }
    
    }
}


