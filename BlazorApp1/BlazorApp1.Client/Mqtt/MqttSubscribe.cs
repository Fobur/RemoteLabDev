using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Extensions.TopicTemplate;

namespace BlazorApp1.Client.Mqtt
{
    public class MqttSubscribe
    {
        static MqttTopicTemplate sampleTemplate = new MqttTopicTemplate("mqttnet/samples/topic/{id}");

        public static async Task Subscribe_Multiple_Topics(IMqttClient client, string[] topics)
        {
            /*
             * This sample subscribes to several topics in a single request.
             */

            var mqttFactory = new MqttFactory();
            var topicFilterBuilder = new MqttTopicFilterBuilder();
            foreach(var topic in topics)
            {
                topicFilterBuilder.WithTopic(topic);
            }
            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(topicFilterBuilder.Build())
                    .Build();
            var response = await client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
            Console.WriteLine($"Mqtt client subscribed to topics: '{String.Join(",", topics)}'.");
        }

        public static async Task Subscribe_Topic(IMqttClient client , string topic)
        {
            var mqttFactory = new MqttFactory();
            var topicFilterBuilder = new MqttTopicFilterBuilder();
            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(topicFilterBuilder.WithTopic(topic))
                    .Build();
            var response = await client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
            Console.WriteLine($"Mqtt client subscribed to topic '{topic}'.");
        }
    }
}
