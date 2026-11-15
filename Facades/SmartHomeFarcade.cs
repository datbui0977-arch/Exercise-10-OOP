using System;
using SmartHomeMini.Interfaces;
using SmartHomeMini.Configurations;

namespace SmartHomeMini.Facades
{
    public sealed class SmartHomeFacade
    {
        private readonly IDevice light;
        private readonly IDevice fan;
        private readonly ILockable door;

        public SmartHomeFacade(
            IDevice light,
            IDevice fan,
            ILockable door)
        {
            this.light = light;
            this.fan = fan;
            this.door = door;
        }

        public void GoToWork()
        {
            Console.WriteLine("\n=== GO TO WORK ===");

            light.TurnOff();
            fan.TurnOff();
            door.Lock();
        }

        public void GoToSleep()
        {
            Console.WriteLine("\n=== GO TO SLEEP ===");

            fan.TurnOff();
            door.Lock();
            light.TurnOn();

            int level =
                HomeConfiguration.Instance.NightLightLevel;

            Console.WriteLine(
                $"Night light level: {level}%");
        }
    }
}