namespace Reckonr
{
    public enum Dimension : long
    {
        Undefined = 0x_0000_0000_0000_0000,
        Time = 0x_0000_0000_0000_0001,
        Length = 0x_0000_0000_0000_0100,
        Mass = 0x_0000_0000_0001_0000,
        ElectricCurrent = 0x_0000_0000_0100_0000,
        Temperature = 0x_0000_0001_0000_0000,
        AmountOfSubstance = 0x_0000_0100_0000_0000,
        LuminousIntensity = 0x_0001_0000_0000_0000
    }
}
