using Eventfully.Application.AWS.S3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventfully.Application.AWS.S3.Interfaces
{
    public interface IStorageService
    {
        Task<S3ResponseDto> UploadFileAsync(S3Object s3obj, AwsCredentials awsCredentials);
    }
}
