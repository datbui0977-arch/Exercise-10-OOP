using System;
using SmartHomeMini.Interfaces;

namespace SmartHomeMini.Devices
{
    public class SmartFan : IDevice
    {
        private string name;

        public SmartFan(string name)
        {
            this.name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine($"{name}: ON");
        }

        public void TurnOff()
        {
            Console.WriteLine($"{name}: OFF");
        }
    }
}