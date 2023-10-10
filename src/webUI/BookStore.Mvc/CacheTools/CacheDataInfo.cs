using BookStore.DataTransferObjects.Responses;

namespace BookStore.Mvc.CacheTools
{
    public class CacheDataInfo
    {
        public IEnumerable<CategoryDisplayResponse> Categories { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
