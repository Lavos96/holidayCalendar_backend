using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HolidaysCalendar.Core.Models
{
    public class Type
    {
        public Type()
        {
            Requests = new Collection<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}