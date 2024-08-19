using System;
using System.Numerics;

//public class 에어컨클래스설계
//{
//    static void Main()
//    {
//        AirConditioner airConditioner = new AirConditioner("Off", 20);
//        airConditioner.PowerOn();
//        airConditioner.PowerInfo();
//        airConditioner.TempUp();
//        airConditioner.TempInfo();
//        airConditioner.TempDown();
//        airConditioner.TempInfo();
//        airConditioner.PowerOff();
//        airConditioner.PowerInfo();
//    }
//}

//public class AirConditioner
//{
//    private string power;
//    private int temp = 20;

//    public AirConditioner(string power, int temp)
//    {
//        this.power = power;
//        this.temp = temp;
//    }

//    public void PowerOn()
//    {
//        Console.WriteLine("전원 켜기");
//        power = "On";
//    }

//    public void PowerOff()
//    {
//        Console.WriteLine("전원 끄기");
//        power = "Off";
//    }

//    public void TempUp()
//    {
//        Console.WriteLine("온도 올리기");
//        if (power == "On") ++temp;
//    }

//    public void TempDown()
//    {
//        Console.WriteLine("온도 내리기");
//        if (power == "On") --temp;

//    }

//    public void PowerInfo()
//    {
//        Console.WriteLine($"전원 상태 : {power}");
//    }

//    public void TempInfo()
//    {
//        Console.WriteLine($"설정된 온도 : {temp}");
//    }
//}

public class AirConditioner
{
    public const int MIN_TEMP = 18;
    public const int MAX_TEMP = 28;
    public bool Power;
    public int Temperature;

    public void TurnOn()
    {
        Power = true;
        Temperature = (MIN_TEMP + MAX_TEMP) / 2;
    }

    public void TurnOff()
    {
        Power = false;
    }

    public void UpTemp()
    {
        ++Temperature;

        Temperature = Math.Min(Temperature, MAX_TEMP);

        //if (Temperature > MAX_TEMP)
        //{
        //    Temperature = MAX_TEMP;
        //}
    }

    public void DownTemp()
    {
        --Temperature;
        Temperature = Math.Max(Temperature, MAX_TEMP);
    }

    public void PrintPowerState()
    {
        string printString = (Power) ?
            "전원이 켜졌습니다." : "전원이 꺼졌습니다.";
        Console.WriteLine(printString);
    }

    public void PrintTemperature()
    {
        Console.WriteLine($"현재 온도는 {Temperature}'C 입니다.");
    }
}

public class _04
{
    static void Main()
    {
        AirConditioner ac = new AirConditioner();

        ac.TurnOn();
        ac.PrintPowerState();
        ac.UpTemp();
        ac.PrintTemperature();
        ac.DownTemp();
        ac.PrintTemperature();
        ac.TurnOff();
        ac.PrintPowerState();
    }
}
