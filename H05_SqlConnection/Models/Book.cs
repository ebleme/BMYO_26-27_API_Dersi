using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace H05_SqlConnection.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        // Data Aannotations
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public bool Ok { get; set; } = true;


        //public List<Author> Authors { get; set; }

        [JsonIgnore]
        public List<Print>? Prints { get; set; }

    }
}
