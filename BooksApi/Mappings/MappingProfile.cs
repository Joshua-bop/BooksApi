using AutoMapper;
using BooksApi.Models;
using BooksApi.Models.RequestDtos;
using BooksApi.Models.RequestDtos;

namespace BooksApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookRequestDto, Book>();
        }
    }
}
