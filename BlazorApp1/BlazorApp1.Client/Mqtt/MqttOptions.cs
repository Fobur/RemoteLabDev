using Microsoft.Extensions.Options;
using MQTTnet.Client;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace BlazorApp1.Client.Mqtt
{
    public static class MqttOptions
    {
        private static X509Certificate2Collection _caChain = SetSertificate();


        private static X509Certificate2Collection SetSertificate()
        {
            var caChain = new X509Certificate2Collection();
            caChain.ImportFromPemFile(@".\cert\root_ca.crt");
            return caChain;
        }
    

        public static MqttClientOptions WebSocketOptions()
        {
            return new MqttClientOptionsBuilder()
                    .WithWebSocketServer(o => o.WithUri("ws://10.40.81.71:9001"))
                    .WithClientId(Guid.NewGuid().ToString())
                    .Build();
        }

        public static MqttClientOptions WebSocketTlsOptions()
        {
            return new MqttClientOptionsBuilder()
                    .WithWebSocketServer(o => o.WithUri("wss://10.40.81.71:9001"))
                    .WithClientId(Guid.NewGuid().ToString())
                    .WithTlsOptions(
                        o =>
                        {
                            // The used public broker sometimes has invalid certificates. This sample accepts all
                            // certificates. This should not be used in live environments.
                            o.WithCertificateValidationHandler(_ => true);
                            o.WithIgnoreCertificateRevocationErrors();
                            o.WithAllowUntrustedCertificates();
                            o.WithTrustChain(_caChain);
                            // The default value is determined by the OS. Set manually to force version.
                            o.WithSslProtocols(SslProtocols.Tls12);
                        })
                    .Build();
        }



        public static MqttClientOptions TslOptions()
        {            
            SetSertificate();
            return new MqttClientOptionsBuilder().WithTcpServer("10.40.81.71", 8883)
                    .WithTlsOptions(
                        o =>
                        {
                            // The used public broker sometimes has invalid certificates. This sample accepts all
                            // certificates. This should not be used in live environments.
                            o.WithCertificateValidationHandler(_ => true);
                            o.WithIgnoreCertificateRevocationErrors();
                            o.WithAllowUntrustedCertificates();
                            o.WithTrustChain(_caChain);
                            // The default value is determined by the OS. Set manually to force version.
                            o.WithSslProtocols(SslProtocols.Tls12);
                        })
                    .WithClientId(Guid.NewGuid().ToString())
                    .Build();
        }

    }
}
