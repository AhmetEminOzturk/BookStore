using AutoMapper;
using BookStore.DataTransferObjects.Requests;
using BookStore.DataTransferObjects.Responses;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Extensions
{
    public static class MappingExtensions
    {
        public static IEnumerable<BookDisplayResponse> ConvertToDisplayResponses(this IEnumerable<Book> books, IMapper mapper)
        {
            return mapper.Map<IEnumerable<BookDisplayResponse>>(books);
        }

        public static IEnumerable<CategoryDisplayResponse> ConvertToDto(this IEnumerable<Category> categories, IMapper mapper)
        {
            return mapper.Map<IEnumerable<CategoryDisplayResponse>>(categories);
        }
        public static IEnumerable<Book> ConvertToCreateBookDto(this IEnumerable<CreateNewBookRequest> books, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Book>>(books);
        }

    }
}
