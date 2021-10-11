using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sukt.LeetCode
{
    /// <summary>
    /// 力扣简单算法题
    /// </summary>
    public static class LeetCodeSimple
    {
        /// <summary>
        /// 整数反转
        /// </summary>
        /// <param name="x"></param>
        public static int Reverse(int x)
        {
            try
            {
                if (x < 0)//判断是否小于0
                {
                    x = -x;
                    string stringX = x.ToString();//将整数转换成string
                    StringBuilder sb = new StringBuilder();
                    List<char> tempX = new List<char>();
                    tempX = stringX.ToList();
                    tempX.Reverse();//使用元素顺序颠倒函数
                    foreach (var c in tempX)
                    {
                        sb.Append(c);
                    }
                    int temp = Convert.ToInt32(sb.ToString());
                    return -temp;
                }
                else
                {
                    string stringX = x.ToString();
                    StringBuilder sb = new StringBuilder();
                    List<char> tempX = new List<char>();
                    tempX = stringX.ToList();
                    tempX.Reverse();
                    foreach (char c in tempX)
                    {
                        sb.Append(c);
                    }
                    int temp = Convert.ToInt32(sb.ToString());
                    return temp;
                }
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 不使用+或-求两数之和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int carry = (a & b) << 1;//使用左移运算符
                a = a ^ b;//如果a!=b,a使用b的值进行覆盖
                b = carry;//
            }
            return a;
        }
        /// <summary>
        /// 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target  的那 两个 整数，并返回它们的数组下标。
        /// 也可以使用排序或者hash表存储访问过的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums,int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if(nums[i]+nums[j]==target)
                    {
                        return  new int[] {i,j };
                    }
                }
            }
            Dictionary
            return new int[] { };
        }
        /// <summary>
        /// 给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }
            return x == revertedNumber || x == revertedNumber / 10;
        }
     }
}
