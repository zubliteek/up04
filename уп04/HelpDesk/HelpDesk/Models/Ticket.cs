using System;

namespace HelpDesk.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
        public string Priority { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int? AssignedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}