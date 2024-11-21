
using BookStore.UI.Models;

namespace BookStore.UI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookListDto>> GetAllBooksAsync();
        Task<BookListDto> AddBookAsync(BookListDto bookDto);
        Task UpdateBookAsync(BookListDto bookDto);
        Task<bool>  DeleteBookAsync(int id);
    }
}
