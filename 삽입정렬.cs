﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_정렬알고리즘
{
    internal class _02삽입정렬
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

            // 삽입 정렬 진행
            InsertionSort(myList);

            Console.WriteLine("정렬 후 요소들 출력.");
            PrintList(myList);
        }

        /// <summary>
        /// 삽입정렬
        /// </summary>
        /// <param name="list"></param>
        private static void InsertionSort(List<int> list)
        {
            void Swap(int index1, int index2)
            {
                int temp = list[index2];
                list[index2] = list[index1];
                list[index1] = temp;
            }
            for (int i = 1; i < list.Count; i++)
            {
                int key = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[key] < list[j])
                    {
                        key = j;
                    }
                }

                if (i != key)
                {
                    Swap(key, i);
                }
            }
        }
    }
}
