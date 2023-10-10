using BookStore.DataTransferObjects.Requests;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Mvc.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookService.GetBookDisplayResponses();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = GetCategoriesForSelectList();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateNewBookRequest request)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBookAsync(request);
                return RedirectToAction(nameof(Index));
            }


            ViewBag.Categories = GetCategoriesForSelectList();
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = GetCategoriesForSelectList();
            var book = await _bookService.GetBookForUpdate(id);

            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateBookRequest updateBookRequest)
        {
            if (await _bookService.BookIsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await _bookService.UpdateBook(updateBookRequest);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Categories = GetCategoriesForSelectList();
                return View();
            }
            return NotFound();
        }
        private IEnumerable<SelectListItem> GetCategoriesForSelectList()
        {
            var categories = _categoryService.GetCategoriesForList().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();
            return categories;
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await _bookService.BookIsExists(id))
            {
                await _bookService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


    }
}
