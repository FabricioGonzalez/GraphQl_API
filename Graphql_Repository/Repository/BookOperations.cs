using Domain.Dto;

using Graphql_Repository.DbModels;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Reflection.Metadata.BlobBuilder;

namespace Graphql_Repository.Repository
{
    public class BookOperations
    {
        private DbSet<BookDbModel> books;
        private DbContext context;
        public BookOperations(DbContext dbContext)
        {
            context = dbContext;
            books = context.Set<BookDbModel>();
        }

        public async Task AddBook(BookDto book)
        {
            try
            {
                var exists = await books
                    .Include(book => book.Auhtor)
                    .FirstOrDefaultAsync(book => book.Auhtor.Name.Equals(book.Auhtor.Name));

                var bookModel = book.toDbModel();

                if (exists is not null)
                {
                    bookModel.Auhtor = exists.Auhtor;
                }

                await books.AddAsync(bookModel);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<BookDto>> GetBooks()
        {
            try
            {
                return await books
                    .Include(book => book.Auhtor)
                    .Select(book => book.toDto())
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
