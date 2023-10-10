using BookStore.DataTransferObjects.Responses;
using BookStore.Mvc.CacheTools;
using BookStore.Mvc.Controllers;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookStore.Mvc.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MenuViewComponent> _logger;

        public MenuViewComponent(ICategoryService categoryService, IMemoryCache memoryCache, ILogger<MenuViewComponent> logger)
        {
            this.categoryService = categoryService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public IViewComponentResult Invoke(int? id = null)
        {
            IEnumerable<CategoryDisplayResponse> categories = getCategoriesMemCacheOrDb(id);      
            return View(categories);
        }
        private IEnumerable<CategoryDisplayResponse> getCategoriesMemCacheOrDb(int? id)
        {

            if (!_memoryCache.TryGetValue("allCategories", out CacheDataInfo cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal);

                cacheDataInfo = new CacheDataInfo
                {
                    CacheTime = DateTime.Now,
                    Categories = categoryService.GetCategoryDisplayResponses()
                };

                _memoryCache.Set("allCategories", cacheDataInfo, options);
            }


            _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz");
            return cacheDataInfo.Categories ;

        }
    }
}
