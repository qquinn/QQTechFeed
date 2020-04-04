using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace DevToReader
{
    [DynamoDBTable("Articles")]
    public class Article
    {
        [DynamoDBProperty("id")]
        public string ArticleID { get; set; }
        public string Title { get; set; }
        [DynamoDBProperty("publish_date")]
        public double PublishDate { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }

    }
}
