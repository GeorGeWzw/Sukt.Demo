using System;

namespace Sukt.LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"字符串反转{ LeetCodeSimple.Reverse(123)}");
            Console.WriteLine($"不使用+或-求两数之和{ LeetCodeSimple.GetSum(2, 3)}");
            Console.WriteLine($"该数组中找出 和为目标值 target  的那 两个 整数----->下标是：{string.Join(",", LeetCodeSimple.TwoSum(new int[] { 2, 7, 11, 15 }, 26))}");
            Console.WriteLine($"给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。----->答案是：{string.Join(",", LeetCodeSimple.IsPalindrome(121))}");
        }

    }
}
