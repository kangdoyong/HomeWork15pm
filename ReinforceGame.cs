using System;
using System.Security.Cryptography;
using System.Threading.Channels;

// 아이템 이름 입력: 
// itemname
// 강화시작 / 강화종료 선택
// reinforcechoice
// 0 ~ 1강 성공
// 강화시작 / 강화종료 선택
// 1 ~ 2강 성공 
// ...
// 4 ~ 5강 성공
// itemname 강화 더이상할수없음

class ReinforceGame
{ 
    static void Main()
    {
        Name name = new Name();
        name.ItemName();
        

        ReinforceStatus reinforcestatus = new();

        

        Console.WriteLine("강화시작 / 강화종료 중 하나를 입력");
        string reinforceinput = Console.ReadLine();
        if (reinforceinput == "강화시작")
        {
            reinforcestatus.reinforceStart();
            
        }
        else if (reinforceinput == "강화종료")
            reinforcestatus.reinforceEnd();
        


        
    }
}


class Name
{
    public void ItemName()
    {
        Console.Write("아이템 이름 입력 : ");
        string itemname = Console.ReadLine();
    }
}

public class Reinforce
{
    Random random = new Random();
    
    public void reinforce01()
    {
        int percentage = 90;
        int randomnumber = random.Next(0,100) + 1;
        if (randomnumber <= percentage)
            Console.WriteLine($"0강 -> 1강 강화 성공!");
    }
    public void reinforce12()
    {
        int percentage = 70;
        int randomnumber = random.Next(0, 100) + 1;
        if (randomnumber <= percentage)
            Console.WriteLine("1강 -> 2강 강화 성공!");
    }
    public void reinforce23()
    {
        int percentage = 50;
        int randomnumber = random.Next(0, 100) + 1;
        if (randomnumber <= percentage)
            Console.WriteLine("2강 -> 3강 강화 성공!");
    }
    public void reinforce34()
    {
        int percentage = 30;
        int randomnumber = random.Next(0, 100) + 1;
        if (randomnumber <= percentage)
            Console.WriteLine("3강 -> 4강 강화 성공!");
    }
    public void reinforce45()
    {
        int percentage = 10;
        int randomnumber = random.Next(0, 100) + 1;
        if (randomnumber <= percentage)
            Console.WriteLine("4강 -> 5강 강화 성공!");
    }
}

class ReinforceStatus
{
    public void reinforceStart()
    {
        Reinforce reinforce = new();

        int num = 0;
        switch(num)
        {
            case 1:
                reinforce.reinforce01();
                break;
            case 2:
                reinforce.reinforce12();
                break;
            case 3:
                reinforce.reinforce23();
                break;
            case 4:
                reinforce.reinforce34();
                break;
            case 5:
                reinforce.reinforce45();
                break;
        }



        

    }
    public void reinforceEnd()
    {
    }

}

class ReinforceChoice
{
    public void Choice()
    {
        Console.WriteLine("강화시작 / 강화종료 중 하나를 입력");
        string reinforceinput = Console.ReadLine();
    }

    
}