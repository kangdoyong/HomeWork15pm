using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_정렬알고리즘
{
    internal class _01선택정렬
    {
        static void Main()
        {
            List<int> myList = new();
            int length = 0;

            bool startSort = false;
            while (!startSort)
            {
                Console.Write("추가할 요소 값 입력(정렬 시작 : \'S\') : ");
                string inputString = Console.ReadLine();

                // 정렬 시작
                if (inputString == "S")
                {
                    startSort = true;
                }
                // 요소 추가
                else
                {
                    int value = int.Parse(inputString);
                    myList.Add(value);
                }
            }

            // 요소 출력
            foreach(int value in myList)
            {
                Console.Write($"[{value}] ");
            }


            // 선택 정렬 진행
            for (int i = 0;  i < myList.Count - 1; ++i)
            {
                int min = i;
                for (int j = i + 1; j < myList.Count; ++j)
                {
                    if (myList[j] < myList[min])
                    {
                        min = j;
                    }
                }
                int temp = myList[i];
                myList[i] = myList[min];
                myList[min] = temp;
            }

            Console.WriteLine();
            Console.WriteLine("선택 정렬 진행 완료");
            foreach (int value in myList)
            {
                Console.Write($"[{value}] ");
            }
        }
    }
}
