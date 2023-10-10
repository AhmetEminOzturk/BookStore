using BookStore.DataTransferObjects.Responses;
using BookStore.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using BookStore.Mvc.Models;
using BookStore.Mvc.Extensions;

namespace BookStore.Mvc.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IBookService bookService;

        public ShoppingController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var basketProcess = GetBasketProcessFromSession();
            return View(basketProcess);
        }
        public IActionResult AddBook(int id)
        {
            BookDisplayResponse selectedBook = bookService.GetBook(id);
            var basketItem = new BasketItem { Book = selectedBook, Quantity = 1};          
            BasketProcess basketProcess = GetBasketProcessFromSession();
            basketProcess.AddNewBook(basketItem);
            SaveToSession(basketProcess);

            return Json(new { message = $"{selectedBook.Title} Sepete eklendi" });
        }


        private BasketProcess GetBasketProcessFromSession()
        {
            return HttpContext.Session.GetJson<BasketProcess>("basket") ?? new BasketProcess();
        }


        private void SaveToSession(BasketProcess basketProcess)
        {
            HttpContext.Session.SetJson("basket", basketProcess);
        }
    }
}
