using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Mqtt.Subscriber
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

            string username = "EFRoG4H8axj2KPbkIJFos";
            string password = "";

            byte code = Client.Connect(Guid.NewGuid().ToString());

            Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;


            if (code == 0x00)
            {
                Console.WriteLine("Subscriber connected to Server node!");
            }
            else
            {
                Console.WriteLine("Connection Refused");
            }
            try
            {
                Client.Subscribe(new string[] { "channel/request" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start: Exception thrown: " + ex.Message);
            }
        }


        static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine(System.Text.Encoding.Default.GetString(e.Message));
        }
    }

}
