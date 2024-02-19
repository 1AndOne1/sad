using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace host
{
    internal class host
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 3000);
            server.Start();
            while (true)
            {
                try
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    NetworkStream stream = client.GetStream();
                }
                catch
                {
                    server.Stop();
                    break;
                }
            }
            if (!true)
            {
                server.Stop();
            }
        }
    }
}
