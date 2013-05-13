using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Interface
{
    class Program
    {
        static Random seed = new Random();
        static Reseau receptionClient;//1337
        static Reseau receptionServeur;//4242
        static Reseau envoieClient;//4243
        static Reseau envoieServeur;//1338
        static string Client = "";
        static string Serveur = "";
        static int i = 0;


        static bool C = false;
        static bool V = false;

        static bool C2 = false;
        static bool V2 = false;

        static bool synchro = false;

        static void Serveur_()
        {

            receptionServeur = new Reseau();
            receptionServeur.intialisationServeur(4242);
            Console.WriteLine("Login J2");

            V = true;
        }

        static void Client_()
        {
            receptionClient = new Reseau();
            receptionClient.intialisationServeur(4243);
            Console.WriteLine("Login J1");
            C = true;
        }

        static void Client_Ping()
        {
            envoieClient = new Reseau();
            envoieClient.initialisationClient(1337);
            Console.WriteLine("Ping J1");
            C2 = true;
        }

        static void Serveur_Ping()
        {

            envoieServeur = new Reseau();
            envoieServeur.initialisationClient(1338);
            Console.WriteLine("Ping J2");
            V2 = true;
        }

        static void Main(string[] args)
        {
            Thread Client__ = new Thread(Client_);
            Thread Serveur__ = new Thread(Serveur_);

            Client__.Start();
            Serveur__.Start();

            i = 1;
            Thread.Sleep(42);
            while (!(C & V)) { Thread.Sleep(500); }

            Thread.Sleep(100);

            Thread Client2 = new Thread(Client_Ping);
            Thread Serveur2 = new Thread(Serveur_Ping);

            Client2.Start();
            Serveur2.Start();

            while (!(C2 & V2)) { Thread.Sleep(500); }
            Thread.Sleep(100);
            while (true)
            {
                int seed_ = seed.Next(1000);

                envoieClient.envoieMessage(System.Convert.ToString(seed_));
                envoieServeur.envoieMessage(System.Convert.ToString(seed_));

                Serveur = receptionServeur.receptionMessage();
                Client = receptionClient.receptionMessage();
                if (i % 100 == 0)
                {
                    Thread.Sleep(20);
                }
                if (!synchro)
                {
                    Thread.Sleep(2500);
                    synchro = true;
                }
                envoieServeur.envoieMessage(Client);
                envoieClient.envoieMessage(Serveur);
                i++;
                Thread.Sleep(1);
            }
        }
    }
}
