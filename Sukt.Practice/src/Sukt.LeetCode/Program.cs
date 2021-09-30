using System;

namespace Sukt.LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetSum(2, 3);

        }
        /// <summary>
        /// 不使用+或-求两数之和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetSum(int a,int b)
        {
            while (b!=0)
            {
                int carry = (a & b) << 1;//使用左移运算符
                a = a ^ b;//如果a!=b,a使用b的值进行覆盖
                b = carry;//
            }
            return a;
        }
    }
}
