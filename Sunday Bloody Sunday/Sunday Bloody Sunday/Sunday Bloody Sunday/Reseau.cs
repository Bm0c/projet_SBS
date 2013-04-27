using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sunday_Bloody_Sunday
{
    class Reseau
    {
        public List<Keys> Liste(string dl)
        {
            List<Keys> liste = new List<Keys>();

            try
            {

                foreach (char a in dl)
                {
                    if (a == '1')
                    {
                        liste.Add(Keys.Z);
                    }
                    else if (a == '2')
                    {
                        liste.Add(Keys.S);
                    }
                    else if (a == '3')
                    {
                        liste.Add(Keys.Q);
                    }
                    else if (a == '4')
                    {
                        liste.Add(Keys.D);
                    }
                    else if (a == '5')
                    {
                        liste.Add(Keys.A);
                    }
                    else if (a == '6')
                    {
                        liste.Add(Keys.E);
                    }
                    else if (a == '7')
                    {
                        liste.Add(Keys.R);
                    }
                    else if (a == 'u')
                    {
                        liste.Add(Keys.Up);
                    }
                    else if (a == 'd')
                    {
                        liste.Add(Keys.Down);
                    }
                    else if (a == 'l')
                    {
                        liste.Add(Keys.Left);
                    }
                    else if (a == 'r')
                    {
                        liste.Add(Keys.Right);
                    }
                    else if (a == 'n')
                    {
                        liste.Add(Keys.N);
                    }
                    else if (a == 'p')
                    {
                        liste.Add(Keys.P);
                    }
                    else if (a == 'e')
                    {
                        liste.Add(Keys.Enter);
                    }
                }
            }
            catch
            {
            }

            return liste;

        }

        Socket Envoie;
        Socket Reception;
        Socket Attente;

        public Reseau()
        {
        }

        public void initialisationClient(int port, ref bool connection)
        {
            try
            {
                Envoie = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Envoie.Connect(IPAddress.Parse("127.0.0.1"), port);
                Envoie.NoDelay = true;
            }
            catch
            {
                try
                {
                    Envoie.Close();
                }
                catch { };

                connection = false;
            }
        }

        public void envoieMessage(string message, ref bool connection)
        {
            try
            {
                byte[] messageLength = BitConverter.GetBytes(message.Length);
                Envoie.Send(messageLength);

                byte[] messageData = System.Text.Encoding.UTF8.GetBytes(message);
                Envoie.Send(messageData);
            }
            catch
            {
                try
                {
                    Envoie.Close();
                }
                catch { };
                connection = false;
            }
        }

        public void intialisationServeur(int port, ref bool connection)
        {
            try
            {
                Attente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Attente.Bind(new IPEndPoint(IPAddress.Any, port));
                Attente.Listen(2);
                Reception = Attente.Accept();
                Reception.NoDelay = true;
            }
            catch
            {
                try { Attente.Close(); }
                catch { }
                try { Reception.Close(); }
                catch { }
                connection = false;
            }
        }

        public string receptionMessage(ref bool connection)
        {
            try
            {
                byte[] messageLengthData = new byte[4];

                Reception.Receive(messageLengthData);
                int messageLength = BitConverter.ToInt32(messageLengthData, 0);

                byte[] messageData = new byte[messageLength];
                Reception.Receive(messageData);

                return System.Text.Encoding.UTF8.GetString(messageData);
            }
            catch
            {
                connection = false;
                try { Attente.Close(); }
                catch { }
                try { Reception.Close(); }
                catch { }
                return "0";
            }
        }

    }
}
