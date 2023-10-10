using BookStore.DataTransferObjects.Requests;
using BookStore.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<BookDisplayResponse> GetBookDisplayResponses();
        IEnumerable<BookDisplayResponse> GetBooksByCategory(int categoryId);
        BookDisplayResponse GetBook(int id);
        Task CreateBookAsync(CreateNewBookRequest createNewBookRequest);
        Task UpdateBook(UpdateBookRequest updateBookRequest);
        Task<bool> BookIsExists(int bookId);
        Task<UpdateBookRequest> GetBookForUpdate(int id);
        Task DeleteAsync(int id);

    }
}
