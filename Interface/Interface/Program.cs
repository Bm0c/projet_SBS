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
        
        static void Main(string[] args)
        {
            int nombre_joueurs = 1;
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
                Console.WriteLine("Ping :" + (i+1));
                i++;
            }

            i = 1;

            foreach(Reseau Client in Clients)
            {
                Client.envoieMessage(System.Convert.ToString(nombre_joueurs));
            }

            Thread.Sleep(5000);

            while (true)
            {
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
                Thread.Sleep(1);

                if (i % 100 == 0)
                {
                    Thread.Sleep(10 * nombre_joueurs * 2);
                }
            }
        }
    }
}
