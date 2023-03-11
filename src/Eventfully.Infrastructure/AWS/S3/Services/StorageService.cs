using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Eventfully.Application.AWS.S3.Interfaces;
using Eventfully.Application.AWS.S3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Eventfully.Infrastructure.AWS.S3.Services
{
    public class StorageService : IStorageService
    {
        public async Task<S3ResponseDto> UploadFileAsync(S3Object s3obj, AwsCredentials awsCredentials)
        {
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecret);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.CACentral1
            };

            var response = new S3ResponseDto();

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3obj.InputStream,
                    Key = s3obj.Name,
                    BucketName = s3obj.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                // create s3 client
                using var client = new AmazonS3Client(credentials, config);

                // upload utility to s2
                var transferUtility = new TransferUtility(client);

                // uploading file
                await transferUtility.UploadAsync(uploadRequest);

                response.StatusCode = 200;
                response.Message = $"{s3obj.Name} has been uploaded successfull";
            }
            catch(AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
