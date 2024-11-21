using AutoMapper;
using BookStore.Application.DTOS;
using BookStore.Application.Interfaces;
using BookStore.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookWithAuthorDto>> GetAllBooksAsync()
        {
            var storedProcedure = "EXEC GetAllBooks";
            var books = await _repository.GetAll<Book>(storedProcedure).ToListAsync();
            if (books == null || !books.Any())
            {
                throw new Exception("No books found.");
            }
            var bookDtos = _mapper.Map<IEnumerable<BookWithAuthorDto>>(books);

            return bookDtos;
        }


        public async Task CreateBookAsync(BookWithAuthorDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@Title", book.Title),
        new SqlParameter("@TypeBook", (object)book.TypeBook ?? DBNull.Value),
        new SqlParameter("@Price", book.Price),
        new SqlParameter("@PublishedDate", (object)book.PublishedDate ?? DBNull.Value),
        new SqlParameter("@AuthorId", book.AuthorId)
            };
            await _repository.CreateAsync("EXEC AddBook @Title, @TypeBook, @Price, @PublishedDate, @AuthorId", parameters);
        }



        public async Task UpdateBookAsync(BookWithAuthorDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@BookId", book.BookId),
        new SqlParameter("@Title", book.Title),
        new SqlParameter("@TypeBook", (object)book.TypeBook ?? DBNull.Value),
        new SqlParameter("@Price", book.Price),
        new SqlParameter("@PublishedDate", (object)book.PublishedDate ?? DBNull.Value),
        new SqlParameter("@AuthorId", book.AuthorId)
            };
            await _repository.Update("EXEC UpdateBook @BookId, @Title, @TypeBook, @Price, @PublishedDate, @AuthorId", parameters);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var storedProcedure = "EXEC DeleteBook @BookId";
            var parameters = new object[]
            {
        new SqlParameter("@BookId", id) 
            };

            var result = await _repository.Delete(storedProcedure, parameters);

            return result > 0;
        }


    }
}
