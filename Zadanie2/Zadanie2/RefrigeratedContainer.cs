namespace Zadanie2;

public class RefrigeratedContainer : Container
{
    public Dictionary<string, double> ProductTypes { get; private set; } // Słownik typu produktu i jego temperatury przechowywania
    public double CurrentTemperature { get; private set; } // Aktualna temperatura w kontenerze
    public string LoadedProduct { get; private set; } // Typ aktualnie załadowanego produktu

    public RefrigeratedContainer(string serialNumber, double ownWeight, double height, double depth, double maxLoadCapacity, Dictionary<string, double> productTypes, double currentTemperature)
        : base(serialNumber, ownWeight, height, depth, maxLoadCapacity)
    {
        ProductTypes = productTypes;
        CurrentTemperature = currentTemperature;
        LoadedProduct = null; // Kontener na początku jest pusty
    }

    public void LoadCargo(double weight, string productType, double temperature)
    {
        if (!ProductTypes.ContainsKey(productType))
        {
            throw new InvalidOperationException($"Produkt typu {productType} nie jest dozwolony w tym kontenerze.");
        }

        if (LoadedProduct != null && LoadedProduct != productType)
        {
            throw new InvalidOperationException($"Kontener już zawiera produkt typu {LoadedProduct}. Nie można załadować produktu innego typu.");
        }

        double allowedTolerance = 1e-5; // Zdefiniuj odpowiednią wartość tolerancji

        if (Math.Abs(temperature - ProductTypes[productType]) > allowedTolerance)
        {
            throw new InvalidOperationException($"Temperatura przechowywania dla produktu {productType} powinna wynosić {ProductTypes[productType]}°C, a nie {temperature}°C.");
        }

        base.LoadCargo(weight);
        LoadedProduct = productType; // Ustawienie załadowanego produktu
        CurrentTemperature = temperature;
    }

    public override string ToString()
    {
        string productInfo = LoadedProduct != null ? $"Załadowany produkt: {LoadedProduct} ({ProductTypes[LoadedProduct]}°C)" : "Brak załadowanego produktu";
        return base.ToString() + $", {productInfo}, Aktualna temperatura: {CurrentTemperature}°C, Obecna waga ładunku: {LoadWeight} kg";
    }
}
