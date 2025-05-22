
namespace Task.Models
{

    public class TaskItem
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string IsCompleted { get; set; }
    }
}