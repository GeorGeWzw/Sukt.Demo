using System;
using System.Collections.Generic;

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
            LeetCodeSimple.FizzBuzz(15);
            LeetCodeSimple.PeakIndexInMountainArray(new int[] { 2, 7, 45, 45, 89, 656, 64656, 7777, 12 });
            Console.WriteLine($"最小操作次数使数组元素相等---->{LeetCodeSimple.MinMoves(new int[] { 1, 1, 1 })}");
            Console.WriteLine($"{ string.Join(" ,", LeetCodeSimple.PlusOne(new int[] {4,3,2,1 }))}");
            Console.WriteLine(LeetCodeSimple.NextGreaterElement(new int[] { 4, 1, 2}, new int[] { 1, 3, 4, 2 }));
            


        }
        
    }
}
