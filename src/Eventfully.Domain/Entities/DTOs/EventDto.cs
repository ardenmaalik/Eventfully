using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventfully.Domain.Entities.DTOs
{
    public class EventDto
    {
        public string EventName { get; set; } = string.Empty;
        public string EventType { get; set; }
        public string EventDescription { get; set; } = string.Empty;
        public string Category { get; set; }
        public int Price { get; set; }
        public string EventThumbnail { get; set; }
        public string EventBanner { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTime { get; set; }
    }
}
