using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore.Utilities.Aws
{
    public static class LambdaExtensions
    {
        private const string DEFAULTSTAGENAME = "";

        public static string GetGatewayStageName(this HttpContext httpContext, ILogger logger = null)
        {
            try
            {
                object obj;
                if (httpContext.Items.TryGetValue("LambdaRequestObject", out obj))
                {
                    var lambdaReq = obj as APIGatewayProxyRequest;
                    if (lambdaReq != null && lambdaReq.RequestContext != null)
                    {
                        return lambdaReq.RequestContext.Stage;
                    }
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "HttpHelper.GetStageName Exception");
            }

            return DEFAULTSTAGENAME;
        }

        public static string GetLambdaFunctionVersion(this HttpContext httpContext, ILogger logger = null)
        {
            try
            {
                object obj;
                if (httpContext.Items.TryGetValue("LambdaContext", out obj))
                {
                    var lambdaContext = obj as ILambdaContext;
                    if (lambdaContext != null)
                    {
                        return lambdaContext.FunctionVersion;
                    }
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "HttpHelper.GetLambdaFunctionVersion Exception");
            }

            return string.Empty;
        }

        public static string GetLambdaFunctionName(this HttpContext httpContext, ILogger logger = null)
        {
            try
            {
                object obj;
                if (httpContext.Items.TryGetValue("LambdaContext", out obj))
                {
                    var lambdaContext = obj as ILambdaContext;
                    if (lambdaContext != null)
                    {
                        return lambdaContext.FunctionName;
                    }
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "HttpHelper.GetLambdaFunctionName Exception");
            }

            return string.Empty;
        }
    }
}
