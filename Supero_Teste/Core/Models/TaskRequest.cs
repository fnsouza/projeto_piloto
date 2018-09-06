using Domain.Enum;

namespace Core.Models
{
    public class TaskRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EStatus Status { get; set; }
    }
}
