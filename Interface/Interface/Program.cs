using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Interface
{

    class Program
    {
        static string buffer;
        static Random seed = new Random();
        static List<Reseau> Clients = new List<Reseau>();

        static int i;
        static bool synchro = false;

        static int nombre_joueurs;

        static void Main(string[] args)
        {
            nombre_joueurs = 2;
            i = 0;
            while (i < nombre_joueurs)
            {
                Reseau Lien = new Reseau();
                Lien.intialisationServeur(1337);
                Lien.envoieMessage(System.Convert.ToString(4242 + i));
                Lien.Attente.Close();
                Lien.Reception.Close();

                Reseau Client = new Reseau();
                Client.intialisationServeur(4242 + i);
                Clients.Add(Client);
                Console.WriteLine("Ping :" + (i + 1));
                i++;
            }

            i = 1;

            foreach (Reseau Client in Clients)
            {
                Client.envoieMessage(System.Convert.ToString(nombre_joueurs));
            }

            Lobby();
            Console.WriteLine("Here we go !");
            Partie();
        }

        static void Lobby()
        {
            Thread.Sleep(3000);
            buffer = "|";
            while (buffer[0] == '|')
            {
                buffer = "";
                foreach (Reseau Client in Clients)
                {
                    Client.receptionMessage();
                    buffer += Client.message;
                }
                Console.WriteLine(buffer);

                //Envoie des messages
                foreach (Reseau Client in Clients)
                {
                    if (buffer[0] == '|')
                        Client.envoieMessage(buffer);
                    else
                        Client.envoieMessage("go");
                }
                Thread.Sleep(10);
            }
        }

        static void Partie()
        {

            while (true)
            {
                int i = 1;
                int seed_ = seed.Next(1000);

                foreach (Reseau Client in Clients)
                {
                    Client.envoieMessage(System.Convert.ToString(seed_));
                }

                buffer = "";

                //Reception des messages
                foreach (Reseau Client in Clients)
                {
                    Client.receptionMessage();
                    buffer += Client.message;
                }

                //Envoie des messages
                foreach (Reseau Client in Clients)
                {
                    Client.envoieMessage(buffer);
                }
                i++;
                Thread.Sleep(10);

                if (i % 1000 == 0)
                {
                    Thread.Sleep(100 * nombre_joueurs * 2);
                }
                if (!synchro)
                {
                    Thread.Sleep(5000);
                    synchro = true;
                }
            }
        }
    }
}
