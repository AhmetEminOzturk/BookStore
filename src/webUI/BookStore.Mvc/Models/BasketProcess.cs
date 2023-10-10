using BookStore.DataTransferObjects.Responses;

namespace BookStore.Mvc.Models
{
    public class BasketProcess
    {
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        public void ClearAll() => BasketItems.Clear();
        public decimal TotalBooksPrice() => BasketItems.Sum(item => (decimal)item.Book.Price * item.Quantity);

        public int TotalBooksCount() => BasketItems.Sum(p => p.Quantity);

        public void AddNewBook(BasketItem basketItem)
        {
            var exists = BasketItems.FirstOrDefault(c => c.Book.Id == basketItem.Book.Id);
            if (exists != null)
            {
                exists.Quantity += basketItem.Quantity;
            }
            else
            {
                BasketItems.Add(basketItem);
            }

        }

    }

    public class BasketItem
    {
        public BookDisplayResponse Book { get; set; }
        public int Quantity { get; set; }

    }
}

