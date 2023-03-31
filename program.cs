using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    abstract class BaseRovnice
    {
        public double a;
        public double b;

        public BaseRovnice(double A, double B)
        {
            a = A;
            b = B;
        }
        public virtual void ZjistiKorenyRovnice()
        {
        }
        public virtual void VypisRovnice()
        {
        }
    }
    class LinearniRovnice : BaseRovnice
    {
        public LinearniRovnice(int A,int B) : base (A, B)
        {
        }
        public override void ZjistiKorenyRovnice()
        {
            Console.WriteLine("x =  " + -b / a);
        }
        public override void VypisRovnice()
        {
            Console.WriteLine(a + "x + " + b);
        }
    }
    class KvadratickaRovnice : BaseRovnice
    {
        public double c;
        public KvadratickaRovnice(int A, int B, int C) : base(A, B)
        {
            c = C;
        }
        public override void ZjistiKorenyRovnice()
        {
            double diskriminant = Math.Pow(b,2) - 4 * a * c;

            if(diskriminant == 0)
            {
                Console.WriteLine("x = " + ((-b + 0)/(2 * a)));
            }
            else if(diskriminant >= 1)
            {
                Console.WriteLine("x1 = " + ((-b - Math.Sqrt(diskriminant)/(2 * a))));
                Console.WriteLine("x2 = " + ((-b - Math.Sqrt(diskriminant) / (2 * a))));
            }
            else if(diskriminant < 0)
            {
                Console.WriteLine("Nemá řešení v reálných číslech");
            }
        }
        public override void VypisRovnice()
        {
            Console.WriteLine(a + "x^2 + " + b + "x + " + c);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<LinearniRovnice> Linearni_rovnice = new List<LinearniRovnice>();
            List<KvadratickaRovnice> Kvadraticka_rovnice = new List<KvadratickaRovnice>();

            LinearniRovnice lin0 = new LinearniRovnice(1, 2);
            LinearniRovnice lin1 = new LinearniRovnice(3, 4);
            LinearniRovnice lin2 = new LinearniRovnice(5, 6);

            KvadratickaRovnice kvad0 = new KvadratickaRovnice(1, 2, 3);
            KvadratickaRovnice kvad1 = new KvadratickaRovnice(4, 5, 6);
            KvadratickaRovnice kvad2 = new KvadratickaRovnice(7, 8, 9);

            Linearni_rovnice.Add(lin0);
            Linearni_rovnice.Add(lin1);
            Linearni_rovnice.Add(lin2);

            Kvadraticka_rovnice.Add(kvad0);
            Kvadraticka_rovnice.Add(kvad1);
            Kvadraticka_rovnice.Add(kvad2);

            for(int i = 0; i < Linearni_rovnice.Count; i++)
            {
                Linearni_rovnice[i].VypisRovnice();
                Linearni_rovnice[i].ZjistiKorenyRovnice();
            }
            for (int i = 0; i < Kvadraticka_rovnice.Count; i++)
            {
                Kvadraticka_rovnice[i].VypisRovnice();
                Kvadraticka_rovnice[i].ZjistiKorenyRovnice();
            }
            
        }
    }
}
