using System;
public class 구구단_프로젝트
{
    static void Main()
    {
        //int num1 = 1;
        //int num2 = 1;

        //int result = 0;
        //while (num1 < 10)
        //{
        //    Console.WriteLine($"{num1}단 출력");
        //    num2 = 1;
        //    while (num2 < 10)
        //    {
        //        result = num1 * num2;
        //        Console.WriteLine($"{num1}*{num2}={result}");
        //        ++num2;
        //    }
        //    ++num1;
        //}

        int a = 1;

        while (a < 10)
        {
            int b = 1;

            Console.WriteLine($"{a}단 출력.");
            while (b < 10)
            {
                Console.WriteLine($"{a} X {b} = {(a * b)}");
                ++b;
            }
            ++a;
            Console.WriteLine();
        }
    }
}
