/*
    简单的计算器程序，帮助初学者了解C#代码
 
 */


using System;

namespace count.number
{
    class ClassSum
    {
        public static void Main(string[] args)
        {
            char operation;
            double last = 0D;
            Console.WriteLine("请输入第一个数字:");
            string str1 = Console.ReadLine();
            double num1 = IsNumber(str1);

            Console.WriteLine("请输入第二个数字:");
            string str2 = Console.ReadLine();
            double num2 = IsNumber(str2);

            Console.WriteLine("请输入操作符 (+, -, *, /):");
            operation = Convert.ToChar(Console.ReadLine());

            double result = PerformCalculation(num1, num2, operation);
            if (result is double)
            {
                double OkRes = Math.Round(result, 4);
                Console.WriteLine($"结果是: {num1} {operation} {num2} = {OkRes}");
                last = result;
            }
            else
            {
                Environment.Exit(0);
                Console.WriteLine("无效的操作!");
            }

            while (true)
            {
                Console.WriteLine("请继续输入数字:");
                string VarStr = Console.ReadLine();
                double VarNum = IsNumber(VarStr);
                Console.WriteLine("请输入操作符 (+, -, *, /):");
                char ope = Convert.ToChar(Console.ReadLine());
                double r = PerformCalculation(last, VarNum, ope);
                if (r is double)
                {
                    double OkResult = Math.Round(r, 4);
                    Console.WriteLine($"结果是: {last} {ope} {VarNum} = {OkResult}");
                    last = r;
                }
                else
                {
                    Environment.Exit(0);
                    Console.WriteLine("无效的操作!");
                }
            }

            Console.ReadKey();
        }

        public static double IsNumber(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("请输入正确的数字");
                Environment.Exit(0);
            }
            if (double.TryParse(str, out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("请输入正确的数字");
                Environment.Exit(0);
            }
            return result;
        }

        public static double PerformCalculation(double num1, double num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 != 0) return num1 / num2;
                    break;
                default:
                    return double.NaN; // Not a Number, 表示无效操作
            }
            return double.NaN;
        }
    }
}