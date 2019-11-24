using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bravi.Atilio.Test
{
    class Program
    {
        public static bool CheckString(string input)
        {   
            var pairs = new Dictionary<char, char>() {
                { '}','{' },  { ']','[' },   { ')','(' }
            };   
            
            var history = new Stack<char>();

            foreach (char c in input)
            {
                if (pairs.ContainsValue(c)) history.Push(c);
                if (pairs.ContainsKey(c) && (history.Count == 0 || history.Pop() != pairs[c]))
                    return false;
            }
            return (history.Count == 0);
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                input = "{[()]} }[]{ {()[] {()[]} ({)}";

            var data = input.Split(' ')
                            .Select(s => new { Input = s, Result = CheckString(s) ? "IS VALID" : "IS NOT VALID" });

            foreach (var item in data)
            {   
                Console.WriteLine("{0,-26} \t--{1,5}", item.Input, item.Result);
            }

            var result = data.Select(i => i.Result).ToArray();

            Console.ReadKey(true);
        }
    }
}
