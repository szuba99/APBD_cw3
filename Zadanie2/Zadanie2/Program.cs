using System;
using System.Collections.Generic;

namespace Zadanie2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Tworzenie dwóch statków
            var ship1 = new ContainerShip(30, 10, 50000);
            var ship2 = new ContainerShip(25, 8, 40000);

            // Wyświetlanie początkowych informacji o statkach
            Console.WriteLine("Informacje o statkach przed załadunkiem:");
            Console.WriteLine("Statek 1:");
            Console.WriteLine(ship1);
            Console.WriteLine("Statek 2:");
            Console.WriteLine(ship2);

            // Tworzenie słownika z produktami i ich temperaturami
            var productTypes = new Dictionary<string, double>
            {
                { "Bananas", 13.3 },
                { "Chocolate", 18.0 },
                { "Fish", 2.0 },
                { "Meat", -15.0 },
                { "Icecream", -18.0 },
                { "Frozen pizza", -30.0 },
                { "Cheese", 7.2 },
                { "Sausages", 5.0 },
                { "Butter", 20.5 },
                { "Eggs", 19.0 }
            };

            // Tworzenie i załadunek kontenerów
            var refrigeratedContainer1 = new RefrigeratedContainer("KON-C-1", 2200, 120, 250, 24000, productTypes, -18.0);
            refrigeratedContainer1.LoadCargo(1000, "Icecream", -18.0);

            var refrigeratedContainer2 = new RefrigeratedContainer("KON-C-2", 2200, 120, 250, 24000, productTypes, -15.0);
            refrigeratedContainer2.LoadCargo(800, "Meat", -15.0);

            var nonRefrigeratedContainer1 = new Container("KON-N-1", 1500, 120, 250, 15000);
            nonRefrigeratedContainer1.LoadCargo(700);

            var nonRefrigeratedContainer2 = new Container("KON-N-2", 1500, 120, 250, 15000);
            nonRefrigeratedContainer2.LoadCargo(600);

            // Dodanie kontenerów na wodę
            var liquidContainer1 = new LiquidContainer("KON-L-1", 2000, 120, 250, 18000, true, 5.0);
            liquidContainer1.LoadCargo(1000); // Załadunek wody o wadze 1000 kg

            var liquidContainer2 = new LiquidContainer("KON-L-2", 2000, 120, 250, 18000, false, 7.0);
            liquidContainer2.LoadCargo(1200); // Załadunek wody o wadze 1200 kg

            // Załadunek kontenerów na statek 1
            ship1.AddContainer(refrigeratedContainer1);
            ship1.AddContainer(refrigeratedContainer2);
            ship1.AddContainer(nonRefrigeratedContainer1);
            ship1.AddContainer(nonRefrigeratedContainer2);
            ship1.AddContainer(liquidContainer1);
            ship1.AddContainer(liquidContainer2);

            // Wyświetlanie informacji o statkach po załadunku
            Console.WriteLine("\nInformacje o statkach po załadunku:");
            Console.WriteLine("Statek 1:");
            Console.WriteLine(ship1);
            Console.WriteLine("Statek 2:");
            Console.WriteLine(ship2);

            // Wyświetlanie informacji o kontenerach w statku 1
            Console.WriteLine("\nInformacje o kontenerach na statku 1:");
            foreach (var container in ship1.Containers)
            {
                Console.WriteLine(container);
            }

            // Usunięcie kontenera z statku 1
            Console.WriteLine("\nUsuwanie kontenera o numerze seryjnym KON-C-1...");
            ship1.RemoveContainer("KON-C-1");

            // Wyświetlanie informacji o statku 1 po usunięciu kontenera
            Console.WriteLine("\nInformacje o statku 1 po usunięciu kontenera:");
            Console.WriteLine("Statek 1:");
            Console.WriteLine(ship1);

            // Przenoszenie kontenera z jednego statku na drugi
            Console.WriteLine("\nPrzenoszenie kontenera KON-C-2 na statek 2...");
            ship1.TransferContainer(ship2, "KON-C-2");

            // Wyświetlanie informacji o statkach po przeniesieniu kontenera
            Console.WriteLine("\nInformacje o statkach po przeniesieniu kontenera:");
            Console.WriteLine("Statek 1:");
            Console.WriteLine(ship1);
            Console.WriteLine("Statek 2:");
            Console.WriteLine(ship2);

            // Wyświetlanie liczby kontenerów na każdym statku
            Console.WriteLine("\nLiczba kontenerów na każdym statku:");
            Console.WriteLine($"Statek 1: {ship1.Containers.Count}");
            Console.WriteLine($"Statek 2: {ship2.Containers.Count}");
        }
    }
}
