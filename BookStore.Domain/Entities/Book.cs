using System;
using System.Collections.Generic;

namespace BookStore.Infrastructure;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? TypeBook { get; set; }

    public decimal Price { get; set; }

    public DateOnly? PublishedDate { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
