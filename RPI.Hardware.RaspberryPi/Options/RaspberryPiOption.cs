using System.Collections.Generic;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Hardware.RaspberryPi.Options;

public class RaspberryPiOption
{
    public const string SectionName = "RaspberryPi";
    
    public Dictionary<string, PinMode> PinsConfiguration { get; set; }
}