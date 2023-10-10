using AutoMapper;
using BookStore.DataTransferObjects.Requests;
using BookStore.DataTransferObjects.Responses;
using BookStore.Entities;
using BookStore.Infrastructure.Repositories;
using BookStore.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService       
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<bool> BookIsExists(int bookId)
        {
            return await _bookRepository.IsExistsAsync(bookId);
        }

        public async Task CreateBookAsync(CreateNewBookRequest createNewBookRequest)
        {
            var book = _mapper.Map<Book>(createNewBookRequest);
            await _bookRepository.CreateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public BookDisplayResponse GetBook(int id)
        {
            var book = _bookRepository.Get(id);
            return _mapper.Map<BookDisplayResponse>(book);
        }

        public IEnumerable<BookDisplayResponse> GetBookDisplayResponses()
        {
            var books = _bookRepository.GetAll();
            var response = books.ConvertToDisplayResponses(_mapper);
            return response;
        }

        public async Task<UpdateBookRequest> GetBookForUpdate(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            return _mapper.Map<UpdateBookRequest>(book);
        }

        public IEnumerable<BookDisplayResponse> GetBooksByCategory(int categoryId)
        {
            var books = _bookRepository.GetBooksByCategory(categoryId);
            var response = books.ConvertToDisplayResponses(_mapper);
            return response;
        }

        public async Task UpdateBook(UpdateBookRequest updateBookRequest)
        {
            var book = _mapper.Map<Book>(updateBookRequest);
            await _bookRepository.UpdateAsync(book);
        }
    }
}
