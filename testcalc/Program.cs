using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testcalc {
    class Number {
        public string Value { get; }
        public int Base { get; }

        public Number(string value, int @base) {
            Value = value;
            Base = @base;
        }

        public override string ToString() {
            return $"{Value}:{Base}";
        }
    }

    class Program 
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("На Ваш выбор представлены функции, которые вы можете выполнить с числами:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Перевод числа из одной системы счисления в другую.");
            Console.WriteLine("2. Перевод целого арабского числа в римскую систему счисления.");
            Console.WriteLine("3. Перевод числа из римской системы счисления в арабскую.");
            Console.WriteLine("4. Сложение чисел в произвольной системе счисления.");
            Console.WriteLine("0. Выход из приложения");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Выберите функцию, которую хотите запустить: ");
            Console.WriteLine("\n");
            
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Выбрано неверное число. Попробуйте еще раз.");
                    break;
            }
            

            }

        public static void Task1()
        {
            Console.WriteLine("\n\n");
            Console.Write("Введите систему счисления из которой нужно перевести: ");
            int system1 = int.Parse(Console.ReadLine());
            Console.Write("Введите число: ");
            string value1 = Console.ReadLine();
            
            Console.Write("Введите систему счисления в которую нужно перевести: ");
            int system2 = int.Parse(Console.ReadLine());
            
            Number number1 = new Number(value1, system1);
            
            Console.WriteLine("Результат выполнения: " + ConvertNotation(number1, system2).Value);
            
        }

        public static void Task2()
        {
            Console.WriteLine("Введите любое арабское число:");
            if (uint.TryParse(Console.ReadLine(), out uint number))
                Console.WriteLine(ToRoman(number));
            else
                Console.WriteLine("Try again");
        }

        public static void Task3()
        {
            Console.WriteLine("Введите римское число: ");
            string input = Console.ReadLine();
            Console.WriteLine(FromRoman(input));
        }

        public static void Task4()
        {
            Console.WriteLine("Введите систему счисления: ");
                int numBase = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите число 1: ");
                int value1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите число 2: ");
                int value2 = int.Parse(Console.ReadLine());

                StringBuilder sum = new StringBuilder("");
                int onMind = 0;

                int tempValue1 = value1;
                int tempValue2 = value2;

                while (sum.ToString() != getUniversalSumExpected(value1, value2, numBase))
                {
                    Console.Clear();
                    Console.WriteLine("  " + value1);
                    
                    Console.WriteLine("+ " + getOffset(value1, value2) + value2);
                    Console.WriteLine("------------- (в уме " + onMind + ")");
                    Console.WriteLine(getResultOffset(value1, sum.ToString()) + sum);

                    int lastFirst = tempValue1 % 10;
                    int lastSecond = tempValue2 % 10;
                    
                    tempValue1 /= 10;
                    tempValue2 /= 10;
                    int lastSum = lastFirst + lastSecond + onMind;
                    onMind = 0;
                    
                    if (lastSum >= numBase && lastSecond != 0)
                    {
                        lastSum -= numBase;
                        onMind++;
                    }

                    sum.Insert(0, numBase >= 16 ? ConvertToSymbol(lastSum).ToString() : lastSum.ToString());
                    
                    Thread.Sleep(1000);
                }
                
                Console.Clear();
                Console.WriteLine("  " + value1);
                Console.WriteLine("+ " + getOffset(value1, value2) + value2);
                Console.WriteLine("------------- (в уме " + onMind + ")");
                Console.WriteLine(getResultOffset(value1, sum.ToString()) + sum);
        }
        static string getUniversalSumExpected(int num1, int num2, int baze)
        {
            int number1dec = FromAnyToDec(num1.ToString(), baze);
            int number2dec = FromAnyToDec(num2.ToString(), baze);
            int result = number1dec + number2dec;
            return FromDecToAny(result, baze);
        }

        static string getOffset(int num1, int num2)
        {
            int diff = num1.ToString().Length - num2.ToString().Length;
            string offset = "";
            if (diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {
                    offset += " ";
                }
            }

            return offset;
        }

        static string getResultOffset(int num1, string result)
        {
            int offsetLength = 2 + num1.ToString().Length;
            offsetLength -= result.Length;
            string offset = "";
            for (int i = 0; i < offsetLength; i++)
            {
                offset += " ";
            }

            return offset;
        }


        static int FromAnyToDec(string number, int baze) {
            if (baze > 50)
                throw new ArgumentException("База должна быть меньше или равна 50");
            int result = 0;
            int digitsCount = number.Length;
            int num;

            for (int i = 0; i < digitsCount; i++) {
                char c = number[i];

                if (c >= '0' && c <= '9')
                    num = c - '0';
                else if (c >= 'A' && c <= 'Z')
                    num = c - 'A' + 10;
                else if (c >= 'a' && c <= 'z')
                    num = c - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Неверное число");

                if (num >= baze)
                    throw new ArgumentException("Строка содержит недопустимые символы.");

                result *= baze;
                result += num;
            }
            return result;
        }

        static string FromDecToAny(int number, int baze) {
            if (baze > 50)
                throw new ArgumentException("Base should be less than or equal 50");
            StringBuilder builder = new StringBuilder();

            do {
                int mod = number % baze;
                char c = ConvertToSymbol(mod);
                builder.Append(c);
                number /= baze;
            } while (number >= baze);

            if (number != 0) {
                builder.Append(ConvertToSymbol(number));
            }

            return string.Join("", builder.ToString().Reverse());
        }

        private static char ConvertToSymbol(int mod) {
            if (mod >= 0 && mod <= 9)
                return (char)('0' + mod);
            if (mod >= 10 && mod <= 36)
                return (char)('A' + mod - 10);
            if (mod >= 37 && mod <= 62)
                return (char)('a' + mod - 36);
            throw new ArgumentException("Illegal statement");
        }


        public static Number ConvertNotation(Number number, int targetBaze) {
            int dec = FromAnyToDec(number.Value, number.Base);
            string targetValue = FromDecToAny(dec, targetBaze);
            return new Number(targetValue, targetBaze);
        }


        private static uint[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] rum = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        static string ToRoman(uint number) {
            if (number > 5000)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("Число должно быть меньше или равно 5000");
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < nums.Length && number != 0; i++) {
                while (number >= nums[i]) {
                    number -= nums[i];
                    result.Append(rum[i]);
                }
            }

            return result.ToString();
        }

        static uint FromRoman(string romanNumber)
        {
            uint sum = 0;
            for (int i = 0; i < romanNumber.Length; i++)
            {
                string chars;
                if (i + 1 >= romanNumber.Length) 
                    chars = romanNumber[i].ToString();
                else
                    chars = "" + romanNumber[i] + romanNumber[1+i++];

                if (rum.Contains(chars))
                    sum += nums[Array.IndexOf(rum, chars)];
                else
                {
                    char[] charsSplitted = chars.ToCharArray();
                    foreach (char rumNum in charsSplitted)
                    {
                        int index = Array.IndexOf(rum, rumNum.ToString());
                        sum += nums[index];
                    }
                }
            }

            return sum;
        }
    }
}