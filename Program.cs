using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Задача_1__Перестановки_
{
    class Program
    {
        static List<string> Reshuffles;
        static string regPattern = @"^\w{1,8}$";
        static int Fact(int num)
        {
            if (num == 1)
                return 1;
            return num * Fact(num - 1);
        }
        static bool CheckReg(string str)
        {
            Regex reg = new Regex(regPattern);
            return reg.IsMatch(str);
        }
        static void InputStr(out string cur)
        {
            StreamReader nwReader = new StreamReader(@"input.txt", Encoding.Default);
            cur = nwReader.ReadToEnd().Trim();
            if (!CheckReg(cur))
                cur = "Строка задана некорректно";
            nwReader.Close();
        }
        static void GetAllReshuffles(string curStr, char[] stack)
        {
            bool flag = false;
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i] != 0)
                {
                    flag = true;
                    stack[i]--;
                    GetAllReshuffles(curStr + (char)i, stack);
                    stack[i]++;
                }
            }
            if (!flag)
                Reshuffles.Add(curStr);
        }
        static void OutputReshuffles()
        {
            StreamWriter nwWriter = new StreamWriter(@"output.txt", false, Encoding.Default);
            foreach (string x in Reshuffles)
                nwWriter.WriteLine(x);
            nwWriter.Close();
        }
        static char[] GetStack(string anc)
        {
            char[] cur = new char[256];
            foreach (char x in anc)
                cur[(int)x]++;
            return cur;
        }
        static void Main(string[] args)
        {
            string inpStr;
            InputStr(out inpStr);
            Reshuffles = new List<string>(Fact(inpStr.Length));
            char[] stack = GetStack(inpStr);
            GetStack(inpStr);
            GetAllReshuffles("", stack);
            OutputReshuffles();
        }
    }
}
