using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Book
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }

        public Book(long id, string title, string author, int price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
