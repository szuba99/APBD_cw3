public class OverfillException : Exception
{
    public string ContainerSerialNumber { get; private set; }

    public OverfillException(string containerSerialNumber)
        : base($"Przekroczono pojemność kontenera: {containerSerialNumber}.")
    {
        ContainerSerialNumber = containerSerialNumber;
    }

    public OverfillException(string message, string containerSerialNumber)
        : base(message)
    {
        ContainerSerialNumber = containerSerialNumber;
    }

    public OverfillException(string message, Exception inner, string containerSerialNumber)
        : base(message, inner)
    {
        ContainerSerialNumber = containerSerialNumber;
    }
}