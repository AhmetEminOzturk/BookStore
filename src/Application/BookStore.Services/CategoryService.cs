using AutoMapper;
using BookStore.DataTransferObjects.Responses;
using BookStore.Infrastructure.Repositories;
using BookStore.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<CategoryDisplayResponse> GetCategoriesForList()
        {
            var items = _repository.GetAll();
            var responses = items.ConvertToDto(_mapper);
            return responses;
        }

        public IEnumerable<CategoryDisplayResponse> GetCategoryDisplayResponses()
        {
            var categories = _repository.GetAll();
            var response = categories.ConvertToDto(_mapper);
            return response;
        }
    }
}
