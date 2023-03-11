using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventfully.Domain.Entities
{
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoThumbnail { get; set; }
        public string StartsAt { get; set; }
        public string EndsAt { get; set; }
        public string Length { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
