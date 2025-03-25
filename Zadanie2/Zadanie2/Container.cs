namespace Zadanie2;

public class Container : IHazardNotifier
{
    public string SerialNumber { get; private set; }
    public double LoadWeight { get; private set; }
    public double OwnWeight { get; private set; }
    public double Height { get; private set; }
    public double Depth { get; private set; }
    public double MaxLoadCapacity { get; private set; }

    public Container(string serialNumber, double ownWeight, double height, double depth, double maxLoadCapacity)
    {
        SerialNumber = serialNumber;
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
        MaxLoadCapacity = maxLoadCapacity;
        LoadWeight = 0;
    }

    public virtual void LoadCargo(double weight)
    {
        if (LoadWeight + weight > MaxLoadCapacity)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
        }
        LoadWeight += weight;
    }


    public void NotifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"Zagrożenie: Kontener {containerSerialNumber} przekroczył maksymalną ładowność.");
    }

    public virtual void UnloadCargo()
    {
        Console.WriteLine("Kontener bazowy - wyładunek ładunku.");
    }

    public override string ToString()
    {
        return $"Kontener {SerialNumber}: Masa ładunku = {LoadWeight} kg, Wysokość = {Height} cm, Głębokość = {Depth} cm, Waga własna = {OwnWeight} kg, Maks. ładowność = {MaxLoadCapacity} kg";
    }
}