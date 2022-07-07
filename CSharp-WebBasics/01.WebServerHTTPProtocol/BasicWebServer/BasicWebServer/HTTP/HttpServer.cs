using BasicWebServer.Demo.HTTP;
using BasicWebServer.Demo.Interface;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Demo
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener tcpListener;


        private readonly RoutingTable routingTable;

        public HttpServer(string _address, int _port, Action<IRoutingTable> action)
        {
            ipAddress = IPAddress.Parse(_address);
            port = _port;

            tcpListener = new TcpListener(ipAddress, port);

            action(routingTable = new RoutingTable());
        }
        public HttpServer(int port, Action<IRoutingTable> action)
            : this("127.0.0.1", port, action)
        {

        }
        public HttpServer( Action<IRoutingTable> action)
           : this(8080, action)
        {

        }

        public void Start()
        {
            tcpListener.Start();
            Console.WriteLine($"Server is listening on port {port}!");
            Console.WriteLine("Server is ready for request!");

            while (true)
            {
                var connection = tcpListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = Request.Parse(requestText);

                var response = this.routingTable.MatchRequest(request);

                 WriteRespond(networkStream, response);
                
                connection.Close();
            }

        }

        private static void WriteRespond(NetworkStream networkStream, Response response)
        {

            var contentLenght = Encoding.UTF8.GetBytes(response.ToString());
                                                          
            networkStream.Write(contentLenght);
        }
        private string ReadRequest(NetworkStream networkStream)
        {

            var bufferLenght = 1024;
            var buffer = new byte[bufferLenght];
            var totalBytes = 0;

            var requestBiuld = new StringBuilder();


            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLenght);
                totalBytes += bytesRead;

                if (totalBytes> 10* 1024)
                {
                    throw new InvalidOperationException("Request is too long!");
                }

                requestBiuld.Append(Encoding.UTF8.GetString(buffer, 0, bufferLenght));

            } while (networkStream.DataAvailable);


            return requestBiuld.ToString();
        }
    }
}
