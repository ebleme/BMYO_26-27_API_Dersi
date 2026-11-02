using System.ComponentModel.DataAnnotations;

namespace H05_SqlConnection.DTOs
{
    public class PrintInsertDto
    {
        public int BookId { get; set; }
        public string Name { get; set; }

        public string TranslatorName { get; set; }

    }
}
