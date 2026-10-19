using BookStore.Models;

namespace BookStore.Data
{
    // Mock Database
    public static class AppDataContext
    {
        public static List<Book> books = new List<Book>();

        static AppDataContext()
        {
            books = new List<Book>()
            {
                new Book() { Id = 1, Title = "Mesnevi", Price = 75},
                new Book() { Id = 2, Title = "Lügat-ı Türk", Price = 125},
                new Book() { Id = 3, Title = "Kaşağı", Price = 75},
            };
        }
    }
}
