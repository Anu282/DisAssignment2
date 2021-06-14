  
using System;
using System.Collections.Generic;
using System.Linq;

namespace DisAssignment2
{
    class Program
    {
        /* Self Reflection: time taken 1 week
         * Topics Learned: Lists,Dictionary,Arrays
         * Recommendations:https://docs.microsoft.com/en-us/dotnet/csharp/*/
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1,7, 9, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            //int[] ar3 = { 1, 2, 2, 3, 3, 3 };
            //int[] ar3 = { 2, 2, 2, 3, 3, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximunm Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };//{ -2, 1, -3, 4, -1, 2, 1, -5, 4 };//{ 5, 4, -1, 7, 8 };  //
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {/* sort the array and check if the values in each element array greater than or less than element in another array and increment the pointer of the least value array
          * avoid duplicating the values for intersection, and increment array pointer for both arrays when intersection element is found */
            try
            {
                Array.Sort(nums1);
                Array.Sort(nums2);

                int len1 = nums1.Length;
                int len2 = nums2.Length;
                List<int> result = new List<int>() { };
                int i = 0;int j = 0;

                while(i<len1 && j<len2)
                {
                    if(nums1[i]<nums2[j])
                    {
                        i++;
                    }
                    else if(nums1[i]>nums2[j])
                    {
                        j++;
                    }
                    else if(nums1[i]==nums2[j])
                    {
                        if(!result.Contains(nums1[i]))
                        {
                            result.Add(nums1[i]);
                            //Console.Write(nums1[i] + " ");
                            i++;
                            j++;
                        }
                    }
                }
                foreach(var k in result)
                {
                    Console.Write(k+ " ");
                }
                
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {/* Use binary search to find the element if element is not found return high+1 value for inserting the element*/
            try
            {
                Array.Sort(nums);
                int low = 0;
                int high = nums.Length - 1;
                
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (target > nums[mid])
                    {
                        low = mid + 1;
                    }
                    else if (target < nums[mid])
                    {
                        high = mid - 1;
                    }
                    else if (target == nums[mid])
                    {
                        return mid;
                    }
                    
                }

                return high+1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {/* Use dictionary to store the values if dictionary key and values are same and greater than previous lucky number return the lucky number*/
            
            try
            {
                Array.Sort(nums);
                int lucky = -1;
                Dictionary<int, int> dict = new Dictionary<int, int>();
                foreach(int i in nums)
                {
                    if(dict.ContainsKey(i))
                    {
                        dict[i] = dict[i] + 1;
                    }
                    else
                    {
                        dict.Add(i, 1);
                    }
                }
                foreach(var kv in dict)
                {
                    if(kv.Key==kv.Value && lucky<kv.Value)
                    {
                        lucky = kv.Value;
                    }
                }
                return lucky;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {/* generate the numbers based on above criteria*/
            try
            {
                int max = 0;
                int[] nums = new int[n + 1];
                for(int i =0;i<nums.Length;i++)
                {
                    if (i == 0)
                        nums[i] = 0;
                    else if (i == 1)
                        nums[1] = 1;
                    else if (i % 2 == 0)
                        nums[i] = nums[i / 2];
                    else if (i % 2 != 0)
                        nums[i] = nums[(i - 1) / 2] + nums[(i + 1) / 2];

                }
                foreach(int j in nums)
                {
                    if (max < j)
                        max = j;
                }
                return max;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        { /*save source and destination city in dictionary, set first destnation city to destination and check if the destination city is source city in dictionary 
           * if not then return destination city */
            try
            {

                Dictionary<string, string> cities = new Dictionary<string, string>();
                string destination = paths[0][1];

                foreach (var path in paths)
                {
                    cities.TryAdd(path[0], path[1]);
                }
                while (true)
                {
                    cities.TryGetValue(destination, out string value);
                    if (value == null)
                        return destination;
                    else
                        destination = value;
                }
                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

            //Question 6:
            /// <summary>
            //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
            //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
            //You may not use the same element twice, there will be only one solution for a given array
            //Example 1:
            //Input: numbers = [2,7,11,15], target = 9
            //Output: [1,2]
            //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

            /// </summary>
            private static void targetSum(int[] nums, int target)
        {  /* Use two pointer technique to assign starting index and ending index of the array
            * return indices of the array when  sum matches with target*/
            try
            {
                int i = 0;int j = nums.Length - 1;
                int[] result = new int[2];
                while(i<=j)
                {
                    
                    if(nums[i] + nums[j] > target)
                    {
                        j--;
                    }
                    else if(nums[i] + nums[j] < target)
                    {
                        i++;
                    }
                    else if(nums[i] + nums[j] == target)
                    {
                        result[0]=i + 1;
                        result[1]=j + 1;
                        break;
                    }

                }
                foreach( int k in result)
                {
                    Console.Write(k + " ");
                }
               

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)                                          
        {
            /* Create a dictionary to store student id and integer array to store student values and append values to dictionary
             * count the number of students as number of keys in dictionary
             * intialize [numberofstudents,2] matrix to store results
             * Iterate through dictionary values and convert the dictionary values to array and sort them and calculate the topfive sum and average */ 
            try
            {
                int topfive = 5;
                Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
                
                

                for(int i=0;i<items.GetLength(0);i++)
                {
                    
                    
                        if (dict.ContainsKey(items[i, 0]))
                        {
                            dict[items[i, 0]].Add(items[i, 1]);
                        }
                        else
                            dict.TryAdd(items[i, 0], new List<int>() { items[i, 1] });
                                          
                }
                int studentcount = 0;
                foreach(var kv in dict.Keys)
                {
                    studentcount++;
                }
                int[,] output = new int[studentcount, 2];
                int k = 0;int l = topfive;
                foreach(var kv in dict)
                {
                    int sum = 0;topfive = 5;
                    output[k, 0] = kv.Key;
                    int[] temp = kv.Value.ToArray();
                    Array.Sort(temp);
                    for(int j=temp.Length-1;j>=0 && topfive>0 ;j--)
                    {
                        sum = sum + temp[j];
                        topfive--;

                    }
                    output[k,1]= sum / l;
                    k++;

                }
                foreach(int i in output)
                {
                    Console.Write(i + " ");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int n)
        {
            /*(i+n) mod arr.Length rotates the array n digits to right*/
             try
             {
                 int[] res = new int[arr.Length];
                 for(int i=0;i<arr.Length;i++)
                 {
                    res[(i + n) % arr.Length] = arr[i];
                 }

                 foreach(int k in res)
                 {
                     Console.Write(k+" ");
                 }
             }
             catch (Exception)
             {

                 throw;
             }
           
          

        }
        

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr)
        {
            /*For each element in array check if sum of current element and previous sum is greater than current element if not assign currentsum to current element
             * find maximum of previous sum and current sum */
            try
            {
                int max_sum = arr[0];
                int current_sum = max_sum;
                for(int i=1;i<arr.Length;i++)
                {
                    current_sum = Math.Max(current_sum + arr[i],arr[i]);
                    max_sum = Math.Max(max_sum, current_sum);
                }
                return max_sum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {   /* skip paying for a step when cost is greater for sum of current and current's previous step over previous and previous's previous step*/
            try
            {
                int pre = 0, cur = 0;
                for (int i = 2; i <= costs.Length; ++i)
                {
                    (pre, cur) = (cur, Math.Min(cur + costs[i - 1], pre + costs[i - 2]));
                }
                return cur;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

