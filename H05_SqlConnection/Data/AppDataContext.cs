using H05_SqlConnection.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace H05_SqlConnection.Data
{
    public class AppDataContext: DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        DbSet<Book> Books { get; set; }
    }
}
