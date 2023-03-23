using System.ComponentModel.DataAnnotations;

namespace Social_Network.Models
{
    public class Newsfeed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]  
        public string Message { get; set; }
    }
}
