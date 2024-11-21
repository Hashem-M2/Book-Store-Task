using BookStore.Application.DTOS;
using BookStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookWithAuthorDto>> GetAllBooksAsync();
        Task CreateBookAsync(BookWithAuthorDto book);
        Task UpdateBookAsync(BookWithAuthorDto book);
        Task<bool> DeleteBookAsync(int id);
    }
}
