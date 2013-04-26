using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Interface
{
    class Reseau
    {
        
        Socket Envoie;
        Socket Reception;
        Socket Attente;

        public Reseau()
        {
        }

        public void initialisationClient(int port)
        {
            Envoie = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Envoie.Connect(IPAddress.Parse("127.0.0.1"), port);
            Envoie.NoDelay = true;
        }

        public void envoieMessage(string message)
        {
            byte[] messageLength = BitConverter.GetBytes(message.Length);
            Envoie.Send(messageLength);

            byte[] messageData = System.Text.Encoding.UTF8.GetBytes(message);
            Envoie.Send(messageData);
        }

        public void intialisationServeur(int port)
        {
            Attente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Attente.Bind(new IPEndPoint(IPAddress.Any, port));
            Attente.Listen(2);
            Reception = Attente.Accept();
            Reception.NoDelay = true;
        }

        public string receptionMessage()
        {
            byte[] messageLengthData = new byte[4];

            Reception.Receive(messageLengthData);
            int messageLength = BitConverter.ToInt32(messageLengthData, 0);

            byte[] messageData = new byte[messageLength];
            Reception.Receive(messageData);

            return System.Text.Encoding.UTF8.GetString(messageData);
        }
    
    }
}
