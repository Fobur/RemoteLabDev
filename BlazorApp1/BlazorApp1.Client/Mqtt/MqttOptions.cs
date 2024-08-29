using MQTTnet.Client;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace BlazorApp1.Client.Mqtt
{
    public static class MqttOptions
    {
        public static MqttClientOptions WebSocketOptions()
        {
            return new MqttClientOptionsBuilder()
                    .WithWebSocketServer(o => o.WithUri("ws://localhost:9001//mqtt"))
                    .Build();
        }

        public static MqttClientOptions WebSocketTlsOptions()
        {
            return new MqttClientOptionsBuilder()
                    .WithWebSocketServer(o => o.WithUri("wss://localhost:9001//mqtt"))
                    .WithTlsOptions(
                        o =>
                        {
                            // The used public broker sometimes has invalid certificates. This sample accepts all
                            // certificates. This should not be used in live environments.
                            o.WithCertificateValidationHandler(_ => true);
                            o.WithTrustChain(new X509Certificate2Collection());
                            // The default value is determined by the OS. Set manually to force version.
                            o.WithSslProtocols(SslProtocols.Tls12);
                        })
                    .Build();
        }

        public static MqttClientOptions TslOptions()
        {
            return new MqttClientOptionsBuilder().WithTcpServer("localhost")
                    .WithTlsOptions(
                        o =>
                        {
                            // The used public broker sometimes has invalid certificates. This sample accepts all
                            // certificates. This should not be used in live environments.
                            o.WithCertificateValidationHandler(_ => true);

                            // The default value is determined by the OS. Set manually to force version.
                            o.WithSslProtocols(SslProtocols.Tls12);
                        })
                    .Build();
        }
    }
}
