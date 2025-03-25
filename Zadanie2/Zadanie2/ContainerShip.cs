namespace Zadanie2
{
    public class ContainerShip
    {
        public List<Container> Containers { get; private set; }
        public double MaxSpeed { get; private set; }
        public int MaxContainerCount { get; private set; }
        public double MaxWeight { get; private set; }

        public ContainerShip(double maxSpeed, int maxContainerCount, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainerCount)
            {
                throw new InvalidOperationException("Nie można dodać kontenera. Przekroczono maksymalną liczbę kontenerów na statku.");
            }

            double totalWeight = Containers.Sum(c => c.OwnWeight + c.LoadWeight);
            if (totalWeight + container.OwnWeight + container.LoadWeight > MaxWeight)
            {
                throw new InvalidOperationException("Nie można dodać kontenera. Przekroczono maksymalną wagę ładunku statku.");
            }

            Containers.Add(container);
        }

        public void RemoveContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
            }
            else
            {
                throw new InvalidOperationException("Kontener o podanym numerze seryjnym nie istnieje na statku.");
            }
        }

        public bool ReplaceContainer(string serialNumber, Container newContainer)
        {
            var existingContainer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (existingContainer == null)
            {
                throw new InvalidOperationException($"Kontener o numerze seryjnym {serialNumber} nie został znaleziony.");
            }

            double totalWeight = Containers.Sum(c => c.OwnWeight + c.LoadWeight);
            if (totalWeight - existingContainer.OwnWeight - existingContainer.LoadWeight + newContainer.OwnWeight + newContainer.LoadWeight > MaxWeight)
            {
                throw new InvalidOperationException("Nie można dodać nowego kontenera. Przekroczono maksymalną wagę ładunku statku.");
            }

            if (Containers.Count >= MaxContainerCount)
            {
                throw new InvalidOperationException("Nie można dodać nowego kontenera. Przekroczono maksymalną liczbę kontenerów na statku.");
            }

            Containers.Remove(existingContainer);
            Containers.Add(newContainer);

            Console.WriteLine($"Kontener {serialNumber} został zastąpiony nowym kontenerem.");
            return true;
        }

        public Container GetContainerBySerialNumber(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container == null)
            {
                throw new InvalidOperationException($"Kontener o numerze seryjnym {serialNumber} nie został znaleziony.");
            }
            return container;
        }

        public bool TransferContainer(ContainerShip targetShip, string serialNumber)
        {
            // Sprawdzamy, czy kontener istnieje na obecnym statku
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container == null)
            {
                throw new InvalidOperationException($"Kontener o numerze seryjnym {serialNumber} nie został znaleziony na tym statku.");
            }

            // Sprawdzamy, czy można dodać kontener do statku docelowego
            double totalWeightTarget = targetShip.Containers.Sum(c => c.OwnWeight + c.LoadWeight);
            if (totalWeightTarget + container.OwnWeight + container.LoadWeight > targetShip.MaxWeight)
            {
                throw new InvalidOperationException("Nie można przenieść kontenera. Przekroczono maksymalną wagę ładunku docelowego statku.");
            }

            if (targetShip.Containers.Count >= targetShip.MaxContainerCount)
            {
                throw new InvalidOperationException("Nie można przenieść kontenera. Przekroczono maksymalną liczbę kontenerów na statku docelowym.");
            }
            
            

            // Usuwamy kontener z obecnego statku
            Containers.Remove(container);
            // Dodajemy kontener do statku docelowego
            targetShip.AddContainer(container);

            Console.WriteLine($"Kontener {serialNumber} został pomyślnie przeniesiony na statek docelowy.");
            return true;
        }
        
        public void AddContainers(List<Container> containers)
        {
            foreach (var container in containers)
            {
                AddContainer(container);
            }
        }

        public override string ToString()
        {
            var containerDetails = string.Join("\n", Containers.Select(c => c.ToString()));
            return $"Statek (Prędkość max = {MaxSpeed} węzłów, Max liczba kontenerów = {MaxContainerCount}, Max waga = {MaxWeight} kg):\n{containerDetails}";
        }
    }
}
