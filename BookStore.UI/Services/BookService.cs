using BookStore.UI.Models;
using Microsoft.AspNetCore.Components;


namespace BookStore.UI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookListDto>> GetAllBooksAsync()
        {
           return await _httpClient.GetFromJsonAsync<IEnumerable<BookListDto>>("api/books")
                   ?? new List<BookListDto>();
        }

       
        public async Task<BookListDto?> AddBookAsync(BookListDto bookDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/books", bookDto);


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BookListDto>();
              
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                 Console.WriteLine($"Error adding book: {errorMessage}");
                return null;
            }
        }

        public async Task UpdateBookAsync(BookListDto bookDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Books/{bookDto.BookId}", bookDto);
            response.EnsureSuccessStatusCode();
        }


        public async Task<bool> DeleteBookAsync(int bookId)
        {
            try
            {
                Console.WriteLine($"Sending DELETE request to api/books/{bookId}");

                var response = await _httpClient.DeleteAsync($"api/books/{bookId}");
                Console.WriteLine($"Response status code: {response.StatusCode}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return false;
            }
        }



    }
}
