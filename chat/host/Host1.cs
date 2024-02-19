using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace host
{
    internal class Host1
    {
        static async void Main(string[] args)
        {
            var tspListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
            };
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 12345);
            tspListener.Bind(ipPoint);
            var tcpClient = await tspListener.AcceptAsync();
            System.Console.WriteLine("Есть подключeние");
            tspListener.Listen(0);

            while (true)
            {
                byte[] bytesRead = new byte[255];
                string msg = Encoding.UTF8.GetString(bytesRead);
            }
        }
    }
}
