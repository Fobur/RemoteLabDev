﻿namespace BlazorApp1.Client.Mqtt
{
    public class MqttMessage
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public MqttMessage(string topic, string message)
        {
            Topic = topic;
            Message = message;
        }
    }
}
