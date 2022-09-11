namespace RPI.Core.Devices.RaspberryPi.Enums;

public enum PinChangeTypes
{
    /// <summary>
    /// None.
    /// </summary>
    None = 0,

    /// <summary>
    /// Triggered when pin value goes from low to high.
    /// </summary>
    Rising = 1,

    /// <summary>
    /// Triggered when a pin value goes from high to low.
    /// </summary>
    Falling = 2
}