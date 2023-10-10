using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataTransferObjects.Requests
{
    public class UpdateBookRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kitap adı boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "En az üç karakter kullanabilirsiniz")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter kullanabilirsiniz")]
        public string Title { get; set; }
        [MaxLength(250, ErrorMessage = "En fazla 250 karakter kullanabilirsiniz")]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; } = "https://loremflickr.com/320/240";
        public int? CategoryId { get; set; }
    }
}
