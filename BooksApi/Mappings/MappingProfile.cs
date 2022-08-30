using AutoMapper;
using BooksApi.Models;
using BooksApi.Models.RequestDtos;
using BooksApi.Models.ResponseDtos;
using System.Globalization;

namespace BooksApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookRequestDto, Book>()
                .ForMember(dest =>
                dest.Price,
                opt => opt.MapFrom(src => ConvertStringPriceToInt(src.Price)));

            CreateMap<Book, BookResponseDto>()
                .ForMember(dest =>
                dest.Price,
                opt => opt.MapFrom(src => ConvertIntPriceToStringPrice(src.Price)));
        }

        /// <summary>
        /// use to convert price into its lowest denominator for storage
        /// built assuming currency uses Two decimal places
        /// </summary>
        /// <param name="inputPrice"></param>
        /// <returns></returns>
        private int ConvertStringPriceToInt(string inputPrice)
        {
            inputPrice = inputPrice.Trim();
            if (inputPrice.Contains('.'))
            {
                int indexOf = inputPrice.IndexOf('.');
                int numberOfDecimals = inputPrice.Length - indexOf - 1;
                for (int i = numberOfDecimals; i < 2; i++)
                {
                    inputPrice = inputPrice + "0";
                }
                inputPrice = inputPrice.Replace(".", "");
            }
            else
            {
                inputPrice = inputPrice+"00";
            }

            try
            {
                int formattedInt = Convert.ToInt32(inputPrice);
                return formattedInt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ConvertIntPriceToStringPrice(int inputPrice)
        {
            string formattedPrice = inputPrice.ToString();
            if (formattedPrice.Length < 2)
            {
                for (int i = formattedPrice.Length; i < 2; i++)
                {
                    formattedPrice = formattedPrice + "0";
                }
            }
            int insertPos = formattedPrice.Length - 2;
            formattedPrice = formattedPrice.Insert(insertPos, ".");
            return formattedPrice;
        }
    }
}
