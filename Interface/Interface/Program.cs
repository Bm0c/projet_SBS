using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Interface
{
    class Program
    {
        static Reseau receptionClient;//1337
        static Reseau receptionServeur;//4242
        static Reseau envoieClient;//4243
        static Reseau envoieServeur;//1338
        static string Client = "";
        static string Serveur = "";
        static int i = 0;


        static void Main(string[] args)
        {
            receptionClient = new Reseau();
            receptionClient.intialisationServeur(4243);
            Console.WriteLine("Login J1");

            receptionServeur = new Reseau();
            receptionServeur.intialisationServeur(4242);
            Console.WriteLine("Login J2");

            envoieClient = new Reseau();
            envoieClient.initialisationClient(1337);
            Console.WriteLine("Ping J1");

            envoieServeur = new Reseau();
            envoieServeur.initialisationClient(1338);
            Console.WriteLine("Ping J2");

            i = 1;
            Thread.Sleep(42);
            while (true)
            {

                if (i % 100 == 0)
                {
                    Thread.Sleep(2);
                }
                if (i % 4 == 0)
                {
                    Serveur = receptionServeur.receptionMessage();
                    envoieClient.envoieMessage(Serveur);
                    Console.WriteLine("Envoie J1");
                    Client = receptionClient.receptionMessage();
                    envoieServeur.envoieMessage(Client);
                    Console.WriteLine("Envoie J2");
                }
                else
                {
                    Client = receptionClient.receptionMessage();
                    envoieServeur.envoieMessage(Client);
                    Console.WriteLine("Envoie J2");
                    Serveur = receptionServeur.receptionMessage();
                    envoieClient.envoieMessage(Serveur);
                    Console.WriteLine("Envoie J1");
                }
                i++;
                Thread.Sleep(0);
            }
        }
    }
}
