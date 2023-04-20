using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace Communication.Server
{
    public class MessageReciver
    {
        TcpListener listener;
        IPEndPoint endPoint;

        public MessageReciver(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            listener = new TcpListener(this.endPoint);
            
        }

        public object RecivedMessage()
        {
            dynamic _message;
            listener.Start();
    
            try
            {
                using (var client = listener.AcceptTcpClient())
                {
                    using (var stream = client.GetStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var jsonMessage = reader.ReadLine();
                            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
                            
                            _message = JsonConvert.DeserializeObject<dynamic>(jsonMessage,settings);
                        }
                    }
                }
                
                return _message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
