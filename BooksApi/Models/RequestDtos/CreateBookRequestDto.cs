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
        public int Price { get; set; }

        public CreateBookRequestDto(string title, string author, int price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
