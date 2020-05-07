using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueJoin
{
    class HttpServer
    {
        public const String VERSION = "HTTP/1.0";
        public const String ServerName = "myserver1.1";
        TcpListener listener;
        bool running = false;

        public const String WEB_DIR = "/root/web";

        public HttpServer(int port)
        {
            IPAddress serverIP = IPAddress.Parse("172.20.10.2");
            listener = new TcpListener(serverIP, port);
            
        }

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        private void Run()
        {
            listener.Start();
            running = true;

            Console.WriteLine("server is running");

            while (running)
            {
                Console.WriteLine("waiting for connection");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("client connected");
                HandleClient(client);
                client.Close();
            }

        }

        private void HandleClient(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            String msg = "";

            while (reader.Peek() != -1)
            {
                msg += reader.ReadLine() + "\n";
            }

            Console.WriteLine("Request: \r\n {0}", msg);
            Request request = Request.GetRequest(msg);
            Response response = Response.From(request);
            if (response == null)
            {
                Console.WriteLine("SOSISSISISI");
            }
            response.Post(stream: client.GetStream());
        }
    }
}
