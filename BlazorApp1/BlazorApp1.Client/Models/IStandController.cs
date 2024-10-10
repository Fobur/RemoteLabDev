using static BlazorApp1.Client.Models.Extensions;

namespace BlazorApp1.Client.Models
{
    public interface IStandController
    {
        public StandControllerTypes StandControllerType { get; }
        public string McuPort { get; }
        public string GetTopicToSendMqtt(int standId);
        public string GetTopicToReadMqtt(int standId);
    }
}
