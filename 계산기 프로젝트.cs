using System;
using System.Threading.Channels;

public class 계산기프로젝트
{
    static void Main()
    {
        Console.WriteLine("나만의 멋진 계산기가 실행되었습니다.");
        Console.WriteLine("계산시킬 첫 번째 숫자를 입력하세요 : ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("계산시킬 두 번째 숫자를 입력하세요 : ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("입력받은 숫자들");
        Console.WriteLine(num1);
        Console.WriteLine(num2);
        Console.WriteLine("연산시킬 기호를 선택하세요.");
        Console.Write("+, -, *, / 중 하나를 입력하세요 : ");
        char type = char.Parse(Console.ReadLine());

        Console.WriteLine("결과 : " + (
            (type == '+') ? num1 + num2 :
            (type == '-') ? num1 - num2 :
            (type == '*') ? num1 * num2 :
            (type == '/') ? num1 / num2 :
            "연산자 오류!"));

    }
}