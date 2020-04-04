using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevToReader
{
    public class DynamoAccess
    {

        public DynamoAccess()
        {

        }

        public async Task SaveDataAsync(List<Article> articles)
        {           
            using (IAmazonDynamoDB dbClient = new AmazonDynamoDBClient())
            {

                var config = new DynamoDBContextConfig()
                {
                    ConsistentRead = false,
                    Conversion = DynamoDBEntryConversion.V2
                };

                using (DynamoDBContext context = new DynamoDBContext(dbClient, config))
                {
                    var articleBatch = context.CreateBatchWrite<Article>();
                    articleBatch.AddPutItems(articles);
                    await articleBatch.ExecuteAsync();
                }
            }

        }
    }
}
