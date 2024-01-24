// just for the fun of it
using System;
using System.Threading;
public class VirtualWiFiDriver
{
    public VirtualWiFiDriver(string ssid, string password, bool encryption)
    {
        Connect(ssid, password, encryption);
    }

    public void Connect(string ssid, string password, bool encryption)
    {
        Console.WriteLine($"Connecting to WolFly network: {ssid} with password: {password}");
        Thread.Sleep(4000);
        Console.WriteLine($"encryption: {encryption}");
        Thread.Sleep(200);
        Console.WriteLine($"Connected to {ssid}");
    }

    public void SendData(string data)
    {
        Console.WriteLine($"Sending data over WolFly: {data}");
        Thread.Sleep(200);
        Console.WriteLine($"Succssfully Transfred: {data}");
    }

    public string ReceiveData()
    {
        Console.WriteLine("Receiving data over WolFly");
        
        return "Error Receiving data";
    }
}
