using System;

class Program
{
    static void Main(string[] args)
    {
        // Sample usage
        SmartLight light1 = new SmartLight { _name = "Living Room Light" };
        SmartLight light2 = new SmartLight { _name = "Kitchen Light" };
        SmartHeater heater = new SmartHeater { _name = "Living Room Heater" };
        SmartTV tv = new SmartTV { _name = "Living Room TV" };

        Room livingRoom = new Room();
        livingRoom.Devices.Add(light1);
        livingRoom.Devices.Add(light2);
        livingRoom.Devices.Add(heater);
        livingRoom.Devices.Add(tv);

        livingRoom.TurnOnAllDevices();
        Console.WriteLine("Devices in Living Room:");
        livingRoom.ReportAllDevicesAndStatus();

        Console.WriteLine("\nDevices turned on:");
        foreach (var device in livingRoom.GetDevicesOn())
        {
            Console.WriteLine($"{device._name}");
        }

        SmartDevice longestOnDevice = livingRoom.GetDeviceWithLongestOnTime();
        Console.WriteLine($"\nDevice with the longest on time: {longestOnDevice._name}");

        livingRoom.TurnOffAllDevices();
    }
}