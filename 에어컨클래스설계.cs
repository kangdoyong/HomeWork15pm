using System;
using System.Numerics;

public class 에어컨클래스설계
{
    static void Main()
    {
        AirConditioner airConditioner = new AirConditioner("Off", 20);
        airConditioner.PowerOn();
        airConditioner.PowerInfo();
        airConditioner.TempUp();
        airConditioner.TempInfo();
        airConditioner.TempDown();
        airConditioner.TempInfo();
        airConditioner.PowerOff();
        airConditioner.PowerInfo();
    }
}

public class AirConditioner
{
    private string power;
    private int temp = 20;

    public AirConditioner(string power, int temp)
    {
        this.power = power;
        this.temp = temp;
    }

    public void PowerOn()
    {
        Console.WriteLine("전원 켜기");
        power = "On";
    }

    public void PowerOff()
    {
        Console.WriteLine("전원 끄기");
        power = "Off";
    }

    public void TempUp()
    {
        Console.WriteLine("온도 올리기");
        if (power == "On") ++temp;
    }

    public void TempDown()
    {
        Console.WriteLine("온도 내리기");
        if (power == "On") --temp;

    }

    public void PowerInfo()
    {
        Console.WriteLine($"전원 상태 : {power}");
    }

    public void TempInfo()
    {
        Console.WriteLine($"설정된 온도 : {temp}");
    }
}