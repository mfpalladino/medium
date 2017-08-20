using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new AmazonSimpleNotificationServiceClient(new BasicAWSCredentials("accessKey", "secretKey"), RegionEndpoint.USEast1))
            {
                var myPayload = new MyPayload
                {
                    Prop1 = "Value for property 1",
                    Prop2 = false,
                    Prop3 = 1000
                };

                var response = client.Publish(
                    "arnOfSnsTopic",
                    JsonConvert.SerializeObject(myPayload));
            }
        }
    }

    public class MyPayload
    {
        public string Prop1 { get; set; }
        public bool Prop2 { get; set; }
        public int Prop3 { get; set; }

    }
}
