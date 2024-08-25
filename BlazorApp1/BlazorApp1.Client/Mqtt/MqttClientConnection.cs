using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet;
using System.Security.Authentication;

namespace BlazorApp1.Client.Mqtt
{
    public class MqttClientConnection
    {
        public static async Task Clean_Disconnect(IMqttClient mqttClient)
        {
            /*
             * This sample disconnects in a clean way. This will send a Mqtt DISCONNECT packet
             * to the server and close the connection afterwards.
             *
             * See sample _Connect_Client_ for more details.
             */
            await mqttClient
                .DisconnectAsync(new MqttClientDisconnectOptionsBuilder()
                    .WithReason(MqttClientDisconnectOptionsReason.NormalDisconnection)
                    .Build());
        }

        public static async Task Connect_Client_Timeout()
        {
            /*
             * This sample creates a simple Mqtt client and connects to an invalid broker using a timeout.
             * 
             * This is a modified version of the sample _Connect_Client_! See other sample for more details.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("127.0.0.1").Build();

                try
                {
                    using (var timeoutToken = new CancellationTokenSource(TimeSpan.FromSeconds(1)))
                    {
                        await mqttClient.ConnectAsync(mqttClientOptions, timeoutToken.Token);
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Timeout while connecting.");
                }
            }
        }

        public static async Task Connect_Client_Using_MQTTv5()
        {
            /*
             * This sample creates a simple Mqtt client and connects to a public broker using MQTTv5.
             * 
             * This is a modified version of the sample _Connect_Client_! See other sample for more details.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.hivemq.com").WithProtocolVersion(MqttProtocolVersion.V500).Build();

                // In MQTTv5 the response contains much more information.
                var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                Console.WriteLine("The Mqtt client is connected.");

                response.DumpToConsole();
            }
        }

        public static async Task Connect_Client_Using_TLS_1_2(IMqttClient mqttClient)
        {
            var mqttFactory = new MqttFactory();
            var mqttClientOptions = MqttOptions.TslOptions();

            using (var timeout = new CancellationTokenSource(5000))
            {
                await mqttClient.ConnectAsync(mqttClientOptions, timeout.Token);
            
                Console.WriteLine("The Mqtt client is connected by TSL.");
            }
        }

        public static async Task Connect_Client_Using_WebSockets(IMqttClient mqttClient)
        {
            /*
             * This sample creates a simple Mqtt client and connects to a public broker using a WebSocket connection.
             * 
             * This is a modified version of the sample _Connect_Client_! See other sample for more details.
             */
            var mqttClientOptions = MqttOptions.WebSocketOptions();

            var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            Console.WriteLine("The Mqtt client is connected by WebSockets.");

            response.DumpToConsole();
        }

        public static async Task Connect_Client_With_TLS_Encryption()
        {
            /*
             * This sample creates a simple Mqtt client and connects to a public broker with enabled TLS encryption.
             * 
             * This is a modified version of the sample _Connect_Client_! See other sample for more details.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("test.mosquitto.org", 8883)
                    .WithTlsOptions(
                        o => o.WithCertificateValidationHandler(
                            // The used public broker sometimes has invalid certificates. This sample accepts all
                            // certificates. This should not be used in live environments.
                            _ => true))
                    .Build();

                // In MQTTv5 the response contains much more information.
                using (var timeout = new CancellationTokenSource(5000))
                {
                    var response = await mqttClient.ConnectAsync(mqttClientOptions, timeout.Token);

                    Console.WriteLine("The Mqtt client is connected.");

                    response.DumpToConsole();
                }
            }
        }

        public static async Task Inspect_Certificate_Validation_Errors()
        {
            /*
             * This sample prints the certificate information while connection. This data can be used to decide whether a connection is secure or not
             * including the reason for that status.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("mqtt.fluux.io", 8883)
                    .WithTlsOptions(
                        o =>
                        {
                            o.WithCertificateValidationHandler(
                                eventArgs =>
                                {
                                    eventArgs.Certificate.Subject.DumpToConsole();
                                    eventArgs.Certificate.GetExpirationDateString().DumpToConsole();
                                    eventArgs.Chain.ChainPolicy.RevocationMode.DumpToConsole();
                                    eventArgs.Chain.ChainStatus.DumpToConsole();
                                    eventArgs.SslPolicyErrors.DumpToConsole();
                                    return true;
                                });
                        })
                    .Build();

                // In MQTTv5 the response contains much more information.
                using (var timeout = new CancellationTokenSource(5000))
                {
                    await mqttClient.ConnectAsync(mqttClientOptions, timeout.Token);
                }
            }
        }

        public static async Task Ping_Server()
        {
            /*
             * This is only supported in MQTTv5.0.0+.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = MqttOptions.WebSocketOptions();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                // This will throw an exception if the server does not reply.
                await mqttClient.PingAsync(CancellationToken.None);

                Console.WriteLine("The Mqtt server replied to the ping request.");
            }
        }

        public static void Reconnect_Using_Timer()
        {
            /*
             * This sample shows how to reconnect when the connection was dropped.
             * This approach uses a custom Task/Thread which will monitor the connection status.
             * This is the recommended way but requires more custom code!
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.hivemq.com").Build();

                _ = Task.Run(
                    async () =>
                    {
                        // User proper cancellation and no while(true).
                        while (true)
                        {
                            try
                            {
                                // This code will also do the very first connect! So no call to _ConnectAsync_ is required in the first place.
                                if (!await mqttClient.TryPingAsync())
                                {
                                    await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                                    // Subscribe to topics when session is clean etc.
                                    Console.WriteLine("The Mqtt client is connected.");
                                }
                            }
                            catch
                            {
                                // Handle the exception properly (logging etc.).
                            }
                            finally
                            {
                                // Check the connection state every 5 seconds and perform a reconnect if required.
                                await Task.Delay(TimeSpan.FromSeconds(5));
                            }
                        }
                    });
            }
        }
    }
}
