using System;
using System.Reflection.Metadata.Ecma335;
public class 점수결과출력프로젝트
{
    static void Main()
    {
        int Total(int kor, int eng, int math)
        {
            return kor + eng + math;
        }

        int average(int kor, int eng, int math)
        {
            return (kor + eng + math) / 3;
        }

        int Top(int kor, int eng, int math)
        {
            return kor > eng ? kor :
                   eng > math ? eng :
                   math > kor ? math : kor;
        }

        Console.Write("국어점수를 입력하세요 : ");
        int KOR = int.Parse(Console.ReadLine());
        Console.Write("영어점수를 입력하세요 : ");
        int ENG = int.Parse(Console.ReadLine());
        Console.Write("수학점수를 입력하세요 : ");
        int MATH = int.Parse(Console.ReadLine());
        
        int result1 = Total(KOR, ENG, MATH);
        int result2 = average(KOR, ENG, MATH);
        int result3 = Top(KOR, ENG, MATH);

        Console.WriteLine($"총점 : {result1}");
        Console.WriteLine($"평균 : {result2}");
        Console.WriteLine($"최고점수 : {result3}");
    }
}
