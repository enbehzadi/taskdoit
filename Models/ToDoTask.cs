using System.ComponentModel.DataAnnotations;

namespace NewToDoListApp.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
