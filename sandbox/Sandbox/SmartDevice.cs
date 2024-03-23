abstract class SmartDevice
{
    public string _name { get; set; }
    public bool _isOn { get; protected set; }
    public DateTime _turnedOnTime { get; protected set; }

    public void TurnOn()
    {
        _isOn = true;
        _turnedOnTime = DateTime.Now;
    }
    public void TurnOff()
    {
        _isOn = true;
        _turnedOnTime = DateTime.Now;
    }
    public abstract TimeSpan TimeElapsed();
}

class SmartLight : SmartDevice
{
    public override TimeSpan TimeElapsed()
    {
        return DateTime.Now - _turnedOnTime;
    }
}

class SmartHeater : SmartDevice
{
    public override TimeSpan TimeElapsed()
    {
        return DateTime.Now - _turnedOnTime;
    }
}

class SmartTV : SmartDevice
{
    public override TimeSpan TimeElapsed()
    {
        return DateTime.Now - _turnedOnTime;
    }
}

class Room
{
    public List<SmartDevice> Devices { get; set; } = new List<SmartDevice>();

    public void TurnOnAllDevices()
    {
        foreach (var device in Devices)
        {
            device.TurnOn();
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var device in Devices)
        {
            device.TurnOff();
        }
    }

    public void ReportAllDevicesAndStatus()
    {
        foreach (var device in Devices)
        {
            Console.WriteLine($"{device._name} is {(device._isOn ? "On" : "Off")}");
        }
    }

    public List<SmartDevice> GetDevicesOn()
    {
        return Devices.FindAll(device => device._isOn);
    }

    public SmartDevice GetDeviceWithLongestOnTime()
    {
        SmartDevice longestOnDevice = null;
        foreach (var device in Devices)
        {
            if (longestOnDevice == null || device.TimeElapsed() > longestOnDevice.TimeElapsed())
            {
                longestOnDevice = device;
            }
        }
        return longestOnDevice;
    }
}

class House
{
    public List<Room> Rooms { get; set; } = new List<Room>();
}