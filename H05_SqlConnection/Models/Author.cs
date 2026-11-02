using System.ComponentModel.DataAnnotations;

namespace H05_SqlConnection.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FullName { get; set; }


    }
}
