using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]

namespace DevToReader
{
    public class Function
    {
        
        public void FunctionHandler(string input, ILambdaContext context)
        {
            ReaderClient reader = new ReaderClient();
            var articles = reader.GetArticles();
            DynamoAccess db = new DynamoAccess();
            db.SaveDataAsync(articles).Wait();

        }
    }
}
