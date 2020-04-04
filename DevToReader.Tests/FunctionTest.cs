using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using DevToReader;

namespace DevToReader.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void Test1()
        {
            // Invoke the lambda function.
            var function = new Function();
            var context = new TestLambdaContext();
            function.FunctionHandler("hello world", context);
            Assert.True(true);
        }
    }
}
