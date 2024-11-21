using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthorRepository : Repository, IAuthorRepository
    {
        public AuthorRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
