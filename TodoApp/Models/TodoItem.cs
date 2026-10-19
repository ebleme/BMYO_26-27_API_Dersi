namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }

        // Flag = aktiflik bayrağı,
        public bool Ok { get; set; } = true;
    }
}
