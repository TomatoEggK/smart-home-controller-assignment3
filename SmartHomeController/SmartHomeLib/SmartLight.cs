using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeLib
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; } // 0 to 100
        public string Color { get; private set; } // e.g., "Warm White", "Cool White", "Red", etc.
        public SmartLight(string deviceId, string name) : base(deviceId, name)
        {
            Brightness = 100; // Default brightness
            Color = "White"; // Default color
        }
        public void SetBrightness(int value)
        {
            if (!IsPoweredOn)
                throw new InvalidOperationException("Light must be powered on to change brightness.");
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Brightness must be between 0 and 100.");
            Brightness = value;
        }
        public void SetColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("Color cannot be blank.", nameof(color));
            if (!IsPoweredOn)
                throw new InvalidOperationException("Light must be powered on to change color.");
            Color = color.Trim();
        }
        public override string GetStatus()
        {
            return " Light " + Name + ", Id = " + DeviceId + ", Online is " + IsOnline + ", Power is " + IsPoweredOn + ", Brightness is " + Brightness + ", Color = " + Color;
        }
        public override void ApplyMode(string mode)
        {
            if(string.Equals(mode,"Night") && IsPoweredOn)
            {
                Brightness = 10;
            }
        }

    }
}
