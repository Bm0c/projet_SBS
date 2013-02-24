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
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsGame2
{
    class Serveur
    {
        public static string Charger(string path)
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
            UdpClient serveur = new UdpClient(1337);


            IPEndPoint client = null;
            byte[] data = serveur.Receive(ref client);
            string message = Encoding.Default.GetString(data);

            StreamWriter ecriture = new StreamWriter("lecture");
            ecriture.Write(message);
            ecriture.Close();
            serveur.Close();

        }
    }
}
