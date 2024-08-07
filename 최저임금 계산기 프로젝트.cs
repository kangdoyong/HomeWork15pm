using System;
 
public class 최저임금계산기프로젝트
{
    static void Main()
    {
        //Console.Write("철수가 일한 시간 : ");
        //float time = float.Parse(Console.ReadLine());

        //float pay = 0;
        //int lowpay = 9860;

        //if (time <= 8)
        //    pay = time * 9860;
        //else
        //    pay = time * (1.5f * 9860);

        //Console.Write($"철수가 받는 임금 : {pay}");


        // 최저 임금
        const int RATE = 9860;

        // 최대 시간
        const int MAXHOURS = 24;

        Console.WriteLine("철수는 몇 시간 일했나요?");
        Console.Write("입력 : ");
        int hours = int.Parse(Console.ReadLine());

        if (hours > MAXHOURS)
        {
            Console.WriteLine("일한 시간은 24시간을 초과할 수 없습니다.");
            hours = MAXHOURS;
        }

        int pay;

        // 8시간 초과
        if (hours > 8)
        {
            float overtime = hours - 8;

            pay = (int)(overtime * RATE * 1.5) + (8 * RATE);
        }
        // 8 시간을 초과하지 않은 경우
        else pay = (hours * RATE);

        Console.WriteLine($"철수의 임금은 {pay}원 입니다.");
    }   
}
