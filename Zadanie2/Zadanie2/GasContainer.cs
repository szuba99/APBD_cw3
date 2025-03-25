namespace Zadanie2;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; } // Ciśnienie w atmosferach

    public GasContainer(string serialNumber, double ownWeight, double height, double depth, double maxLoadCapacity, double pressure)
        : base(serialNumber, ownWeight, height, depth, maxLoadCapacity)
    {
        if (pressure < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pressure), "Ciśnienie nie może być ujemne.");
        }
        Pressure = pressure;
    }


    public void NotifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"UWAGA! Niebezpieczna sytuacja w kontenerze {containerSerialNumber}!");
    }

    public override void UnloadCargo()
    {
        // Implementacja wyładunku dla gazowego kontenera
        Console.WriteLine("Wyładunek ładunku gazowego.");
    }
}