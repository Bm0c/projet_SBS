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

namespace Sunday_Bloody_Sunday
{
    class Lobby
    {
        public Input chat;
        public bool Go = false;
        public bool connection = true;
        public int rdy = 0;
        public int id_joueur = 0;
        public int nb_joueur = 1;
        public string[] historique = new string[10];

        public Lobby(IPAddress IP)
        {
            for (int i = 0; i < 10; i++)
            {
                historique[i] = "";
            }
            Reseau.initialisationClient(1337, IP, ref connection);
            int port = System.Convert.ToInt32(Reseau.receptionMessage(ref connection));
            Reseau.Envoie.Close();
            Reseau.initialisationClient(port, IP, ref connection);
            id_joueur = port - 4242;
            nb_joueur = System.Convert.ToInt32(Reseau.receptionMessage(ref connection));
            Reseau.nb_joueurs = nb_joueur;
            chat = new Input();
        }

        public void Envoie(bool message, int idmap, int rdy, ref bool connection)//| + id_joueur + _ + rdy + _ + idmap + _ + message
        {
            if (!Go)
            {
                this.rdy = rdy;
                string buffer = "|";
                buffer += System.Convert.ToString(id_joueur);
                buffer += '_';
                buffer += System.Convert.ToString(rdy);
                buffer += '_';
                buffer += System.Convert.ToString(idmap);
                buffer += '_';
                if (message)
                {
                    buffer += chat.input;
                    chat.input = "";
                }
                Reseau.envoieMessage(buffer, ref connection);
            }
            else
            {
                Reseau.envoieMessage("42", ref connection);
            }
        }

        public bool Reception()
        {
            string message = Reseau.receptionMessage(ref connection);
            if (Go)
            { return true; }
            else
            {
                string[] joueurs = message.Split(new char[1] { '|' });
                //Check des rdy, 4ème char
                int i = 1;
                bool Go1 = true;
                while (i <= nb_joueur)
                {
                    Go1 = Go1 && (joueurs[i][2] == '1');
                    i++;
                }
                if (Go1)
                {
                    i = 2;
                    char buffer = joueurs[1][4];
                    while (i <= nb_joueur)
                    {
                        Go1 = Go1 && (buffer == joueurs[i][4]);
                        i++;
                    }
                    Go = Go1;
                }
                foreach (string message_ in joueurs)
                    gestionChat(message_);
                return false;
            }
        }

        public void gestionChat(string message)
        {
            if (message.Length > 6)
            {
                string buffer = "";
                int i = 6;
                while (i < message.Length)
                {
                    buffer += message[i];
                    i++;
                }

                i = 0;
                while (i < historique.Length - 1)
                {
                    historique[i] = historique[i + 1];
                    i++;
                }
                historique[i] = buffer;
            }
        }

        public void Update(KeyboardState keyboard, KeyboardState old)
        {
            chat.Update(keyboard, old);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            chat.DrawButton(spritebatch);
            int i = 0;
            while (i < 10)
            {

                spritebatch.DrawString(Ressources.HUD, historique[i], new Vector2(0, (i + 1) * 30), Color.LightGray);
                i++;
            }
        }

    }
}
