using System;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{   

    delegate bool algorithm_condition<T>(T value);
    class Program
    {
        //Перебор делителей
        static bool is_prime_number(int value)
        {
            int j = 0, i = 2;
            while ((i*i <= value) && (j != 1))
            {
                if (value % i == 0)
                    j = 1;

                i++;
            }
            return j != 1;
        }

        static void copy_if<T>(List<T> arr, List<T> arr2, 
            algorithm_condition<T> condition)
        {
            foreach(var item in arr)
            {
                if (condition(item))
                    arr2.Add(item);
            }
        }

        static List<double> two_variable_list_fill(Func<double, double, double> func, int elems_count)
        {
            Random rand = new Random();
            List<double> list = new List<double>();
            for (int i = 0; i < elems_count; i++)
            {
                list.Add(func(rand.Next(0, 10), rand.Next(10, 20)));
            }
            return list;
        }
        
        static void remove_if<T>(ref List<T> arr, 
            Func<T,bool> condition)
        {
            List<T> copy = new List<T>();
            
            foreach(var item in arr)
            {
                if (!condition(item))
                    copy.Add(item);
            }
            arr = copy;
        }

        static void Print_collection<T>(T arr) 
            where T : System.Collections.IEnumerable {
            foreach(var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void Fill_rand_list(ref List<int> arr, int count,
            int left_lim, int right_lim){
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                arr.Add(rand.Next(left_lim, right_lim));
            }
        }

        static void Test_delegates()
        {
            List<int> arr = new List<int>();
            Console.WriteLine("List before functions:\n");
            Fill_rand_list(ref arr, 20, 0, 10);
            Print_collection(arr);
            Console.WriteLine("\nAfter lambda compararsion condition:\n");
            remove_if(ref arr, x => x > 5);
            Print_collection(arr);

            Console.WriteLine("\nAfter is_prime_number condition:\n");
            List<int> copy = new List<int>();
            algorithm_condition<int> condition = is_prime_number;
            copy_if(arr, copy, is_prime_number);
            Print_collection(copy);
        }

        static void Main(string[] args)
        {
            Test_delegates();
        }
    }
}
