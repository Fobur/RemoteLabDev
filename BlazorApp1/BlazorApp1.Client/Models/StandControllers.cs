namespace BlazorApp1.Client.Models
{
    public class StandLED(Extensions.StandControllerTypes standControllerType, string port) : BaseStandController(standControllerType, port), IStandController
    {
        public bool IsOn { get; set; }
        public string GetValue => IsOn ? "1" : "0";
        public string GetClasses => $"{(IsOn ? "bg-success": "bg-secondary")} p-3 rounded-circle span-sm";
    }

    public class StandLever(Extensions.StandControllerTypes standControllerType, string port) : BaseStandController(standControllerType, port), IStandController
    {
        public bool IsOn { get; set; }
        public string GetValue => IsOn ? "1" : "0";
    }

    public class StandButton(Extensions.StandControllerTypes standControllerType, string port) : BaseStandController(standControllerType, port), IStandController
    {
    }

    public class StandSlider(Extensions.StandControllerTypes standControllerType, string port) : BaseStandController(standControllerType, port), IStandController
    {
        private double _value;
        public double Value { get => _value; set { if (value >= 0 || value <= 1) _value = value; } }
    }
}
