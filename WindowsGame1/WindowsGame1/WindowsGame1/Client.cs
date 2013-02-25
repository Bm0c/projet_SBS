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

namespace WindowsGame1
{
    class Client
    {
        public static string Charger()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream("envoie", FileMode.Open, FileAccess.Read);
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

        public static void Enregistrer(object toSave, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(path, FileMode.Create, FileAccess.Write);
                formatter.Serialize(flux, toSave);
                flux.Flush();
            }
            catch { }
            finally
            {
                //Et on ferme le flux.
                if (flux != null)
                    flux.Close();
            }
        }

        public static void Envoie(object o)
        {
            Enregistrer(o, "envoie");

            StreamReader je_suis_un_flux = new StreamReader("envoie");
            string prout = je_suis_un_flux.ReadToEnd();
            byte[] msg = Encoding.Default.GetBytes(prout);
            UdpClient udpClient = new UdpClient();
            udpClient.Send(msg, msg.Length, "127.0.0.1", 55542);
            udpClient.Close();
            je_suis_un_flux.Close();
        }


    }
}
