using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models.RequestDtos
{
    public class CreateBookRequestDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Price { get; set; }

        public CreateBookRequestDto(string title, string author, string price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
