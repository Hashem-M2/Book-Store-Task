using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOS
{
    public class BookWithAuthorDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string? TypeBook { get; set; }
        public decimal Price { get; set; }
        public DateOnly? PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
