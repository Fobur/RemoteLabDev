using static BlazorApp1.Client.Models.Extensions;

namespace BlazorApp1.Client.Models
{
    public class BaseStandController : IStandController
    {
        readonly StandControllerTypes standControllerType;
        readonly string mcuPort;

        public StandControllerTypes StandControllerType { get => standControllerType;}
        public string McuPort { get => mcuPort;}

        public BaseStandController(StandControllerTypes standControllerType, string port)
        {
            this.standControllerType = standControllerType;
            mcuPort = port;
        }

        public string GetTopicToSendMqtt(int standId) => $"/lab/stand/{standId}/gpio/output/{McuPort}";
        public string GetTopicToReadMqtt(int standId) => $"/lab/stand/{standId}/gpio/input/{McuPort}";
    }
}
