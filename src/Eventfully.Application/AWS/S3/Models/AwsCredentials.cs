﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventfully.Application.AWS.S3.Models
{
    public class AwsCredentials
    {
        public string AwsKey { get; set; } = "";
        public string AwsSecret { get; set; } = "";
    }
}
