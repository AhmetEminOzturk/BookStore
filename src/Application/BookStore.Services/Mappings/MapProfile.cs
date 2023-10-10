using AutoMapper;
using BookStore.DataTransferObjects.Requests;
using BookStore.DataTransferObjects.Responses;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Mappings
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDisplayResponse>();
            CreateMap<Category, CategoryDisplayResponse>();
            CreateMap<CreateNewBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>().ReverseMap();
        }
    }
}
