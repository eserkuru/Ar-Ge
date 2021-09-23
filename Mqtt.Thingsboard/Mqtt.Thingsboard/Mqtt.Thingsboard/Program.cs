using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;





namespace Mqtt.Thingsboard
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
        public static void Start()
        {

            // Create client instance 
            Client = new MqttClient("127.0.0.1");   // new MqttClient("localhost");//

            string username = "EFRoG4H8axj2KPbkIJFo";
            string password = "";

            byte code = Client.Connect(Guid.NewGuid().ToString());

            Client.MqttMsgPublished += Client_MqttMsgPublished;


            if (code == 0x00)
            {
                Console.WriteLine("Client connected to Server node!");
            }
            else
            {
                Console.WriteLine("Connection Refused");
            }
            try
            {
                //Client.Subscribe(new string[] { "home/sensor" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                Client.Publish("sensor/home", Encoding.UTF8.GetBytes("yeni test"),MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start: Exception thrown: " + ex.Message);
            }

            Client.Disconnect();

        }

        private static void Client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            // handle message received 
            Console.WriteLine(e.MessageId);
            Console.WriteLine(e.IsPublished);
        }

        static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received 
            Console.WriteLine(System.Text.Encoding.Default.GetString(e.Message));
            Console.WriteLine(e.Topic);

        }
    }

}
