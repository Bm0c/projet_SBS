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
        public static List<Keys> Liste(string dl)
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

        public static string Charger()
        {
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
        }

        public static void Reception()
        {
            UdpClient serveur = null;
            try
            {
                serveur = new UdpClient(55542);

                IPEndPoint client = null;
                byte[] data = serveur.Receive(ref client);
                string message = Encoding.Default.GetString(data);

                StreamWriter ecriture = new StreamWriter("lecture");
                ecriture.Write(message);
                ecriture.Close();
                serveur.Close();
            }
            catch
            {
            }
        }
    }
}
