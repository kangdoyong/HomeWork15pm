namespace _18_정렬알고리즘
{
    internal class _03버블정렬
    {
        static void Main()
        {
            void PrintList(List<int> list)
            {
                // 요소 출력
                foreach (int value in list)
                {
                    Console.Write($"[{value}] ");
                }
                Console.WriteLine();
            }

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

            Console.WriteLine("정렬 전 요소들 출력.");
            PrintList(myList);

            // 버블 정렬 진행
            BubbleSort(myList);

            Console.WriteLine("정렬 후 요소들 출력.");
            PrintList(myList);
        }

        private static void BubbleSort(List<int> list)
        {
            void Swap(int index1)
            {
                int temp = list[index1];
                list[index1] = list[index1 + 1];
                list[index1 + 1] = temp;
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(j);
                    }
                }
            }
        }

    }
}
