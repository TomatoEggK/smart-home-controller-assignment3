using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeLib
{
    public class SecurityCamera : SmartDevice
    {
        public bool IsRecording { get; private set; }
        public int StorageCapacityMB { get; }
        public int StorageUsedMB { get; private set; }
        public SecurityCamera(string deviceId, string name, int storageCapacityMB) : base(deviceId, name)
        {
            if (storageCapacityMB <= 0)
                throw new ArgumentOutOfRangeException(nameof(storageCapacityMB), "Storage capacity must be positive.");
            StorageCapacityMB = storageCapacityMB;
            StorageUsedMB = 0;
            IsRecording = false;
        }
        public void StartRecording()
        {
            if (!IsPoweredOn || !IsOnline)
                throw new InvalidOperationException("Camera must be powered on to start recording.");
            if (StorageUsedMB >= StorageCapacityMB)
                throw new InvalidOperationException("Insufficient storage to start recording.");
            IsRecording = true;
        }
        public void StopRecording()
        {
            IsRecording = false;
        }
        public void SimulateRecording(int minutes)
        {
            if (minutes <= 0)
                throw new ArgumentException("Minutes must be greater than 0.", nameof(minutes));
            if (!IsRecording)
                throw new InvalidOperationException("Camera must be recording to simulate recording.");
            if (StorageUsedMB + minutes * 100 > StorageCapacityMB)
                throw new InvalidOperationException("Recording would exceed storage capacity.");
            StorageUsedMB += minutes * 100;
        }
        public override string GetStatus()
        {
            return " Camera " + Name + ", Id = " + DeviceId + ", Online is " + IsOnline + ", Power is " + IsPoweredOn + ", Recording is " + IsRecording + ", Storage Used = " + StorageUsedMB + "MB / " + StorageCapacityMB + "MB";
        }
        public override void ApplyMode(string mode)
        {
            if (string.Equals(mode, "Night") && IsPoweredOn && !IsRecording && IsOnline)
            {
                StartRecording();
            }
        }
    }
}
