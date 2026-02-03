using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeLib
{
    public class SmartThermostat : SmartDevice
    {
        public int Temperature { get; private set; }
        public SmartThermostat(string deviceId, string name) : base(deviceId, name)
        {
            Temperature = 72; // Default temperature
        }
        public void SetTemperature(int value)
        {
            if (!IsPoweredOn)
                throw new InvalidOperationException("Thermostat must be powered on to change temperature.");
            if (value < 50 || value > 90)
                throw new ArgumentOutOfRangeException(nameof(value), "Temperature must be between 50 and 90 degrees.");
            Temperature = value;
        }
        public override string GetStatus()
        {
            return " Thermostat " + Name + ", Id = " + DeviceId + ", Online is " + IsOnline + ", Power is " + IsPoweredOn + ", Temperature is " + Temperature;
        }
        public override void ApplyMode(string mode)
        {
            if (string.Equals(mode, "Night") && IsPoweredOn)
            {
                Temperature = 65;
            }
        }
    }
}
