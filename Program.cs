using System;
using SmartHomeMini.Interfaces;
using SmartHomeMini.Devices;
using SmartHomeMini.Factories;
using SmartHomeMini.Configurations;
using SmartHomeMini.Facades;

namespace SmartHomeMini
{
    class Program
    {
        static void Main(string[] args)
        {
            // TEST T1: Factory
            Console.WriteLine("===== TEST T1: FACTORY =====");

            IDevice light = DeviceFactory.Create(
                "light", "Living room light");

            IDevice fan = DeviceFactory.Create(
                "fan", "Living room fan");

            IDevice door = DeviceFactory.Create(
                "door", "Main door");

            Console.WriteLine(light.GetType().Name);
            Console.WriteLine(fan.GetType().Name);
            Console.WriteLine(door.GetType().Name);


            // TEST T2: Loại thiết bị không hợp lệ
            Console.WriteLine("\n===== TEST T2: INVALID DEVICE =====");

            try
            {
                IDevice camera = DeviceFactory.Create(
                    "camera", "Security camera");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // TEST T3: Singleton
            Console.WriteLine("\n===== TEST T3: SINGLETON =====");

            var c1 = HomeConfiguration.Instance;
            var c2 = HomeConfiguration.Instance;

            Console.WriteLine(
                ReferenceEquals(c1, c2));


            // Thay đổi cấu hình
            c1.HomeName = "My Smart Home";
            c1.NightLightLevel = 40;

            Console.WriteLine(c2.HomeName);


            // TEST T4 và T5: Facade
            Console.WriteLine("\n===== TEST T4, T5: FACADE =====");

            SmartHomeFacade facade = new SmartHomeFacade(
                light,
                fan,
                (ILockable)door
            );

            // T4: Đi làm
            facade.GoToWork();

            // T5: Đi ngủ
            facade.GoToSleep();
        }
    }
}