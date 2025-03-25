namespace Zadanie2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; private set; }
        public double Temperature { get; set; } // Temperatura utrzymywana w kontenerze

        public LiquidContainer(string serialNumber, double ownWeight, double height, double depth, double maxLoadCapacity, bool isHazardous, double temperature)
            : base(serialNumber, ownWeight, height, depth, maxLoadCapacity)
        {
            IsHazardous = isHazardous;
            Temperature = temperature;
        }

        public void NotifyHazard(string containerSerialNumber)
        {
            Console.WriteLine($"UWAGA! Niebezpieczna sytuacja w kontenerze {containerSerialNumber}!");
        }

        public override void LoadCargo(double weight)
        {
            double capacityLimit = IsHazardous ? 0.5 * MaxLoadCapacity : 0.9 * MaxLoadCapacity;

            if (LoadWeight + weight > capacityLimit)
            {
                NotifyHazard(SerialNumber);
                throw new InvalidOperationException(
                    IsHazardous ? "Niebezpieczny ładunek można załadować maksymalnie do 50% pojemności." : 
                        "Ładunek można załadować maksymalnie do 90% pojemności."
                );
            }
            base.LoadCargo(weight);
        }

        public override void UnloadCargo()
        {
            string unloadingMessage = IsHazardous
                ? $"Wyładunek niebezpiecznego ładunku z kontenera {SerialNumber} w specjalnych warunkach."
                : $"Wyładunek standardowego ładunku z kontenera {SerialNumber}.";

            Console.WriteLine(unloadingMessage);
            base.UnloadCargo();
        }
    }
}