﻿using RPI.Core.Abstract.Messages;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Core.Devices.RaspberryPi.Actions.PinValueChanged;

public record PinValueChangedEvent(int Pin, PinChangeTypes ChangeType) : EventBase;