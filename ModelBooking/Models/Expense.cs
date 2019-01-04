using System;

namespace ModelBookingWPF.Models
{
    public class Expense
    {
        public Guid AssignmentId { get; set; }
        public DateTime date { get; set; }
        public string text { get; set; }
        public double amount{ get; set; }
    }
}