using System.ComponentModel.DataAnnotations;

namespace H05_SqlConnection.Models
{
    public class Print
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public string TranslatorName { get; set; }


        public Book Book { get; set; }
    }
}
