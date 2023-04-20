using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;


namespace Communication.Client
{
    public class MessageSender<T>
    {
        IPEndPoint _endPoint;

        public MessageSender(IPEndPoint endpoint)
        {
            _endPoint = endpoint;

        }
        public void SendMessage(T message)
        {
            

            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect(_endPoint);
                    using (var stream = client.GetStream())
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };

                            var jsonMessage = JsonConvert.SerializeObject(message, settings);
                            writer.Write(jsonMessage);
                            writer.Flush();

                        }
                    }
                }
            }
            catch (ArgumentException aEx)
            {
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }   
        }
    }
}

