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
            //Dictionary
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
        /// <summary>
        /// 判断一个数组中的数值是否能被3\5和3、5整除
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> FizzBuzz(int n)
        {
            string[] arr = new string[n];
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    arr[i - 1] = "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    arr[i - 1] = "Fizz";
                }
                else if (i % 5 == 0)
                {
                    arr[i - 1] = "Buzz";
                }
                else
                {
                    arr[i - 1] = i.ToString();
                }
            }
            return arr;
        }
        /// <summary>
        /// 山脉数组的顶部
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int PeakIndexInMountainArray(int[] arr)
        {
            int n = arr.Length;
            int left = 1, right = n - 2, ans = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] > arr[mid + 1])
                {
                    ans = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return ans;
        }
        /// <summary>
        /// 最小操作次数使数组元素相等
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MinMoves(int[] nums)
        {
            var result=0;
            var minNum=nums.Min();
            foreach (var item in nums)
            {
                result += item - minNum;
            }
            return result;
        }
        /// <summary>
        /// 加一 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length-1; i >= 0; i--)
            {
                if(digits[i]!=9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] result = new int[digits.Length+1];
            result[0] = 1;
            return result;
        }
        public static IList<int> MajorityElement(int[] nums)
        {
            return nums.GroupBy(x => x).Where(x => x.Count() > nums.Length / 3).Select(x => x.Key).ToList();
        }
        /// <summary>
        /// 搜索二维矩阵 II
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int x = 0, y = n - 1;
            while (x < m && y >= 0)
            {
                if (matrix[x][y] == target)
                {
                    return true;
                }
                if (matrix[x][y] > target)
                {
                    --y;
                }
                else
                {
                    ++x;
                }
            }
            return false;
        }
        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            //int x = nums1.Length, y = nums2.Length;
            //int[] result = new int[x];
            //for (int i = 0; i < x; i++)
            //{

            //    int n = 0;
            //    while (n<y&& nums2[n]!=nums1[i])
            //    {
            //        n++;
            //    }
            //    int m = n + 1;
            //    while (m<y&& nums2[m]<nums2[n])
            //    {
            //        ++m;
            //    }
            //    result[i]=m<y?nums2[m]:-1;

            //}

            //return result;


            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            for (int i = nums2.Length - 1; i >= 0; --i)
            {
                int num = nums2[i];
                while (stack.Count > 0 && num >= stack.Peek())
                {
                    stack.Pop();
                }
                dictionary.Add(num, stack.Count > 0 ? stack.Peek() : -1);
                stack.Push(num);
            }
            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; ++i)
            {
                res[i] = dictionary[nums1[i]];
            }
            return res;
        }
    }
}
