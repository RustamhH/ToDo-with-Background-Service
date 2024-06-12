namespace TodoApp.Models.Dtos
{
    public class AddTodoItemDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireTime { get; set; }
        public string UserId { get; set; }
    }
}
