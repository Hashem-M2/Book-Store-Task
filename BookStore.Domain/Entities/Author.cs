using System;
using System.Collections.Generic;

namespace BookStore.Infrastructure;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
