using System;
using SmartHomeMini.Interfaces;
using SmartHomeMini.Devices;

namespace SmartHomeMini.Factories
{
    public static class DeviceFactory
    {
        public static IDevice Create(string type, string name)
        {
            switch (type.Trim().ToLowerInvariant())
            {
                case "light":
                    return new SmartLight(name);

                case "fan":
                    return new SmartFan(name);

                case "door":
                    return new SmartDoor(name);

                default:
                    throw new ArgumentException(
                        $"Unsupported device type: {type}");
            }
        }
    }
}