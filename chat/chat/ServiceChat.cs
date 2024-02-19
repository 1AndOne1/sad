using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using static System.Net.Mime.MediaTypeNames;
using System.ServiceModel;
using System.Text;

namespace chat
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    

    public class ServiceChat : IServiceChat
    {
        List<User> users = new List<User>();
        int newId = 1;
        public async void con()
        {
            var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Подключение к серверу
                await tcpClient.ConnectAsync("192.168.220.229", 12345);
                while (true)
                {
                    var command = OperationContext.Current;

                }
            } catch (Exception ex)
            {

            }
        }

        public int Connect(string name)
        {
            con();
            User user = new User() {
                Id = newId,
                Name = name,
                operationContext = OperationContext.Current
        };

            newId++;

            SendMessage(user.Name + "Has been connected to chat",0);
            users.Add(user);
            return user.Id;
        }

        public void Disconnect(int id)
        {
            con();
            var user = users.FirstOrDefault(x => x.Id == id);
            if(user!=null)
            {
                users.Remove(user);
                SendMessage(user.Name + "Has disconnected", 0);
            }
        }

        public void SendMessage(string message, int id)
        {
            con();
            foreach(var item in users) {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    answer += "- " + user.Name + " ";
                }
                answer += message;

                item.operationContext.GetCallbackChannel<ChatCallBack>().SendMessageCallBack(answer);
            }
        }
        public void ShowMembers(string Name)
        {
            
        }
    }
}
