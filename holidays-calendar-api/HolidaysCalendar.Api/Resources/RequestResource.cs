using System;

namespace HolidaysCalendar.Api.Resources
{
    public class RequestResource
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public DateTime Requested { get; set; }
        public DateTime LastChange { get; set; }
        public TypeResource Type { get; set; }
        public StatusResource Status { get; set; }
    }
}