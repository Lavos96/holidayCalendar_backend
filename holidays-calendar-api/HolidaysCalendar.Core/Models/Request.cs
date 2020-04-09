using System;

namespace HolidaysCalendar.Core.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public DateTime Requested { get; set; }
        public DateTime LastChange { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}