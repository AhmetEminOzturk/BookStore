using BookStore.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDisplayResponse> GetCategoriesForList();
        IEnumerable<CategoryDisplayResponse> GetCategoryDisplayResponses();
    }
}
