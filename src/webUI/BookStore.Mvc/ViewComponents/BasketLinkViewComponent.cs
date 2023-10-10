using BookStore.Mvc.Extensions;
using BookStore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Mvc.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var basketProcess = HttpContext.Session.GetJson<BasketProcess>("basket");
            return View(basketProcess);
        }
    }
}
