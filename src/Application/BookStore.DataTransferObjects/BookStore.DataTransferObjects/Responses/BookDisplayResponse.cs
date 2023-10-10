using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataTransferObjects.Responses
{
    public class BookDisplayResponse
    {
        public int Id { get; set; }
        public  string Title { get; init; }
        public  decimal Price { get; init; }
        public  string ImageUrl { get; init; } = "https://loremflickr.com/320/240";
        public string? Description { get; set; }
        public string AuthorFullname { get; set; }
    }
}
