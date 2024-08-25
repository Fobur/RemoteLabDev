using MQTTnet.Client;
using MQTTnet;

namespace BlazorApp1.Client.Mqtt
{
    public class MqttClientPublish
    {
        public static async Task Publish_Application_Message(IMqttClient client, string topic, string value)
        {
            var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(value)
                    .Build();
            await client.PublishAsync(applicationMessage, CancellationToken.None);
            Console.WriteLine("Mqtt application message is published.");
        }

        public static async Task Publish_Application_Message(IMqttClient client, MqttMessage message)
        {
            await Publish_Application_Message(client, message.Topic, message.Message);
        }

        public static async Task Publish_Multiple_Application_Messages(IMqttClient client, MqttMessage[] messages)
        {
            foreach (var message in messages)
            {
                await Publish_Application_Message(client, message);
            }
        }
    }
}
