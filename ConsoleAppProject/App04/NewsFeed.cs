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
        
        public List<int> Likes;

        public string Author;
        public bool ExitLoop { get; set; }

        public bool NoPosts = false;

        public int VisiblePost { get; set; }

        public int VisiblePostIndex { get; set; }

        public List<Post> Posts { get; set; }
        public string Search { get; set; }  

        private readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            Likes = new List<int>();

            MessagePost post = new MessagePost( "entwan", "Hi! This is pinned post.");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost("Entwan", "homies.jpg", "Me homies today");
            AddPhotoPost(photoPost);
        
        }

        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            if (Posts.Count == 0)
            {
                Console.WriteLine("  -- No posts to display --  "); 

                Console.Clear();
            }
            else
            {
                LoopDisplay();
            }
            
        }

        private void LoopDisplay()
        {
            if (Posts.Count == 0)
            {
                VisiblePostIndex = 0;
            }

            else
            {
                for (VisiblePostIndex = 0; VisiblePostIndex <= Posts.Count; VisiblePostIndex++)
                {
                    ExitLoop = false;

                    //Console.Clear();

                    RepeatFinalPost();

                    if (VisiblePost < Posts.Count - 1)
                    {
                        ShowPost();
                    }

                    Console.WriteLine();

                    string[] choices = new string[]
                    {
                      " 1. Like \n",
                      " 2. Unlike \n",
                      " 3. Remove this post \n",
                      " 4. Remove all posts \n",
                      " 5. Comment on this post \n",
                      " 6. Next post \n",
                      " 7. Main Menu \n"
                    };

                    int choice = ConsoleHelper.SelectChoice(choices);

                    switch (choice)
                    {
                        case 1:
                            LikePost(Posts[VisiblePostIndex]);

                            VisiblePostIndex--;

                            break;

                        case 2:
                            UnlikePost(Posts[VisiblePostIndex]);

                            VisiblePostIndex--;

                            break;

                        case 3:
                            RemovePost();

                            VisiblePostIndex--;

                            break;

                        case 4:
                            RemoveAllPosts();

                            break;

                        case 5:
                            AddComment(Posts[VisiblePostIndex]);

                            VisiblePostIndex--;

                            break;

                        case 6:
                            ShowNextPost();

                            break;

                        case 7:
                            Console.Clear();

                            ExitLoop = true;

                            break;

                        default:
                            break;
                    }

                    if (ExitLoop && NoPosts)
                    {
                        VisiblePost = 0;

                        Console.WriteLine("\n    -- All posts removed --\n");

                        Console.WriteLine();

                        break;
                    }

                    else

                    {
                        if (ExitLoop)
                        {
                            VisiblePost = 0;

                            Console.WriteLine();

                            break;
                        }
                    }
                }
            }
        }

        private void ShowPost()
        {
            Console.WriteLine($"\n    -- Showing {VisiblePost + 1}/" +
                $"{Posts.Count} posts --");

            Posts[VisiblePostIndex].Display();
        }

        private void ShowLastPost()
        {
            Console.WriteLine($"\n    -- Showing {VisiblePost + 1}/" +
                $"{Posts.Count} posts --");

            Posts[VisiblePost].Display();
        }

        private void RepeatFinalPost()
        {
            if (VisiblePostIndex == Posts.Count - 1)
            {
                VisiblePost = Posts.Count - 1;

                VisiblePostIndex = VisiblePost - 1;

                ShowLastPost();

                VisiblePostIndex++;
            }
        }

        public void ShowNextPost()
        {
            if (VisiblePostIndex < Posts.Count - 1)
            {
                VisiblePost++;
            }
            else
            {
                VisiblePostIndex--;

                Console.WriteLine(" -- No posts to display ! --\n"); 
            }
        }

        public static void AddComment(Post post)
        {
            Console.Write("\n    Enter comment > ");

            string text = Console.ReadLine();

            post.AddComment(text);

            Console.WriteLine("\n    -- Comment added --\n");
        }

        private void LikePost(Post post)
        {
             if (!Likes.Contains(VisiblePostIndex))
             {
                    post.Like();

                Console.WriteLine(" -- You liked this post -- ");

                    Likes.Add(VisiblePostIndex);
             }

             else
             {
                    Console.WriteLine(" -- You have already liked this post --\n");
             }
            
        }

        private void UnlikePost(Post post)
        {
            if (Likes.Contains(VisiblePostIndex))
            {
                post.Unlike();

                Console.WriteLine("  -- You unliked this post --\n");

                int like = Likes.FindIndex(x => x == VisiblePostIndex);

                Likes.RemoveAt(like);
            }

            else
            {
                Console.WriteLine("  -- You haven't liked this post yet --\n");
            }
        }

        private void RemoveAllPosts()
        {
            Posts = new List<Post>();

            Console.WriteLine("   -- All posts removed -- \n");

            Console.Clear();

            ExitLoop = true;
        }

        private void RemovePost()
        {
             Posts.RemoveAt(VisiblePostIndex);

             Console.WriteLine( "    -- Post removed --\n");
           
             if (Posts.Count == 1)
             {
                 RemoveAllPosts();
             }

        }
    
    }
}


