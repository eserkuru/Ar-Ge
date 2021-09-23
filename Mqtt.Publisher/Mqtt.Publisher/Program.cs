using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Mqtt.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            client.Start();
            Console.ReadKey();
        }
    }

    class client
    {
        static MqttClient Client;
        private const string jsonData = 
            @"{ ""sourceType"": 1, ""sourceNumber"": 61, ""sourceDescription"": ""Hami Mandıralı"",""callStatus"": 10 }";

        public static void Start()
        {

            Client = new MqttClient("127.0.0.1");

            string username = "Hans";
            string password = "Test";

            byte code = Client.Connect(Guid.NewGuid().ToString(),username,password);

            Client.MqttMsgPublished += Client_MqttMsgPublished;


            if (code == 0x00)
            {
                Console.WriteLine("Publisher connected to Server node!");
            }
            else
            {
                Console.WriteLine("Connection Refused");
            }
            try
            {
                Client.Publish("channel/request", Encoding.UTF8.GetBytes(jsonData), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start: Exception thrown: " + ex.Message);
            }

        }

        private static void Client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            // handle message received 
            Console.WriteLine(e.MessageId);
            Console.WriteLine(e.IsPublished);
        }
    }

}
