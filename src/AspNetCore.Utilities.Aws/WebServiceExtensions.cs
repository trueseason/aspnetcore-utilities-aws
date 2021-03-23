using Amazon.Runtime;
using System;

namespace AspNetCore.Utilities.Aws
{
    public static class WebServiceExtensions
    {
        public static bool IsSuccessStatusCode(this AmazonWebServiceResponse response)
        {
            return (int)response.HttpStatusCode >= 200 && (int)response.HttpStatusCode <= 299;
        }

        public static void EnsureSuccessStatusCode(this AmazonWebServiceResponse response)
        {
            if ((int)response.HttpStatusCode < 200 || (int)response.HttpStatusCode > 299)
            {
                throw new Exception($"AmazonWebService Response validation failed. StatusCode: {response.HttpStatusCode}");
            }
        }
    }
}
