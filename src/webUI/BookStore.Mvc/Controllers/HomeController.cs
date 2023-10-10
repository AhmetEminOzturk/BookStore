using BookStore.DataTransferObjects.Responses;
using BookStore.Mvc.CacheTools;
using BookStore.Mvc.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using X.PagedList;



namespace BookStore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Index(int page=1, int pageSize=4 , int? id=null)
        {
            var books = id == null ? _bookService.GetBookDisplayResponses().ToPagedList(page, pageSize) :
                                   _bookService.GetBooksByCategory(id.Value).ToPagedList(page, pageSize);
            return View(books);
        }
    
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}