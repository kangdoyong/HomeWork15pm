//namespace _18_정렬알고리즘
//{
//    internal class _01선택정렬
//    {
//        static void Main()
//        {
//            List<int> myList = new();
//            int length = 0;

//            bool startSort = false;
//            while (!startSort)
//            {
//                Console.Write("추가할 요소 값 입력(정렬 시작 : \'S\') : ");
//                string inputString = Console.ReadLine();

//                // 정렬 시작
//                if (inputString == "S")
//                {
//                    startSort = true;
//                }
//                // 요소 추가
//                else
//                {
//                    int value = int.Parse(inputString);
//                    myList.Add(value);
//                }
//            }

//            // 요소 출력
//            foreach (int value in myList)
//            {
//                Console.Write($"[{value}] ");
//            }

//            // 선택 정렬 진행
//            for (int i = 0; i < myList.Count - 1; ++i)
//            {
//                int indexpos = i;
//                for (int j = i + 1; j < myList.Count; ++j)
//                {
//                    if (myList[j] < myList[indexpos])
//                    {
//                        indexpos = j;
//                    }
//                }
//                int temp = myList[i];
//                myList[i] = myList[indexpos];
//                myList[indexpos] = temp;
//            }

//            Console.WriteLine();
//            Console.WriteLine("선택 정렬 진행 완료");
//            foreach (int value in myList)
//            {
//                Console.Write($"[{value}] ");
//            }
//        }
//    }
//}

namespace _18_정렬알고리즘
{
    internal class _01선택정렬
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

            // 선택 정렬 진행
            SelectionSort(myList);
            Console.WriteLine("정렬 후 요소들 출력.");
            PrintList(myList);
        }

        private static void SelectionSort(List<int> list)
        {
            void Swap(int index1, int index2)
            {
                int temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }

            for (int i = 0; i < list.Count - 1; ++i)
            {
                int targetIndex = i;

                // 최솟값 탐색
                for (int j = i + 1; j < list.Count; ++j)
                {
                    // 더 작은 값을 찾은 경우
                    if (list[targetIndex] > list[j])
                    {
                        targetIndex = j;
                    }
                }

                // 최솟값을 찾은 경우
                if (i != targetIndex)
                {
                    // 교체합니다.
                    Swap(targetIndex, i);
                }
            }
        }
    }
}
