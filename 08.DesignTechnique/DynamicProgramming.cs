using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DesignTechnique
{
    internal class DynamicProgramming
    {
        /*  동적계획법 ( Dynamic Programming)
         * 
         *  작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
		 *  주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
		 */

        // 예시 - 피보나치 수열

        int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];
            fibonachi[1] = 1;
            fibonachi[2] = 1;

            for (int i = 3; i <= x; i++)
            {
                fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
            }

            return fibonachi[x];
        }

        // 연속합
        static void Main2()
        {
            int[] values = { 1, 2, 3, 4, 5, -99, 16 };
            int max = int.MinValue;


            // ex) [2,4] : 2~4 더한값
            int[,] result = new int[values.Length, values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                result[i, i] = values[i];
                if (max < values[i])
                {
                    max = values[i];
                }
            }

            for (int start = 0; start < values.Length; start++)
            {
                for (int end = start + 1; end < values.Length; end++)
                {
                    result[start, end] = result[start, end - 1] + values[end];
                    if (max < result[start, end])
                    {
                        max = result[start, end];
                    }
                }
            }
            Console.WriteLine(max);

        }



    }
}
