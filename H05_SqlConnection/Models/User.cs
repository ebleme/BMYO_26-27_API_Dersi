using System.ComponentModel.DataAnnotations;

namespace H05_SqlConnection.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        [EmailAddress, MaxLength(30)]
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
