using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventfully.Application.AWS.S3.Models
{
    public class S3Object
    {
        public string Name { get; set; } = null;
        public FileStream InputStream { get; set; } = null;
        public string BucketName { get; set; } = null!;
    }
}
