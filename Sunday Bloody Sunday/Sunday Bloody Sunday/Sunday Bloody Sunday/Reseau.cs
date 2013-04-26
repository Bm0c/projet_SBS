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
<<<<<<< HEAD
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
=======
            Reception();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream("lecture", FileMode.Open, FileAccess.Read);
                return (string)formatter.Deserialize(flux);
            }
            catch
            {
                //On retourne la valeur par défaut du type T.
                return default(string);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
>>>>>>> 33d94ddb3966adf1ccf112c0ccb337962fae5e95
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

<<<<<<< HEAD
            Reception.Receive(messageLengthData);
            int messageLength = BitConverter.ToInt32(messageLengthData, 0);

            byte[] messageData = new byte[messageLength];
            Reception.Receive(messageData);

            return System.Text.Encoding.UTF8.GetString(messageData);
=======
                StreamWriter ecriture = new StreamWriter("lecture");
                ecriture.Write(message);
                ecriture.Close();
                serveur.Close();
            }
            catch
            {
            }
>>>>>>> 33d94ddb3966adf1ccf112c0ccb337962fae5e95
        }

    }
}
