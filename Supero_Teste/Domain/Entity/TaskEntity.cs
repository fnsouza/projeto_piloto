using System;

namespace Domain.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
