using System.ComponentModel.DataAnnotations;

namespace H05_SqlConnection.DTOs
{
    public class PrintsGetByBookIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string TranslatorName { get; set; }

    }
}
