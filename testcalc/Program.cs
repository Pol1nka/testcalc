using System;
using System.Collections.Generic;
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
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Begin();

            try
            {
                StartProgram();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                {
                    Console.WriteLine(ex.Message);
                    Console.Clear();
                }
                else
                    Console.WriteLine(
                        "Некорректный ввод данных, пожалуйста, повторите попытку!");

                Main();
            }
        }

        public static void Begin()
        {
            Console.WriteLine("Здравствуйте! Данный калькулятор разработан для ознакомления с расчётами в различных системах счиления от от 1 до 50, в том числе и Римская СС!");
            Console.WriteLine("Выполнила студентка группы ПрИ-102 Стародубцева Полина.");
            Interface();
            Console.WriteLine("Выберите функцию, которую хотите запустить. ");
        }

        public static void Interface()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("На Ваш выбор представлены функции, которые вы можете выполнить с числами.");
            Console.WriteLine("1. Перевод числа из одной системы счисления в другую.");
            Console.WriteLine("2. Перевод целого числа в римскую систему счисления.");
            Console.WriteLine("3. Перевод числа из римской системы счисления.");
            Console.WriteLine("4. Сложение чисел в произвольной системе счисления.");
            Console.WriteLine("5. Вычитание чисел в произвольной системе счисления.");
            Console.WriteLine("6. Умножение чисел в произвольной системе счисления");
            Console.WriteLine("0. Выход из приложения");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n");
        }

        public static void StartProgram()
        {
            Console.Write("Введите число, соответсвующее функции: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int operation) || !(operation >= 1 && operation <= 8))
                {
                    throw new ArgumentException("");
                }

                switch (operation)
                {
                    case 1:
                        Task1();
                        // Thread.Sleep(200);
                        ContinueOrNo();
                        break;
                    case 2:
                        Task2();
                        // Thread.Sleep(200);
                        ContinueOrNo();
                        break;
                    case 3:
                        // Task3();Thread.Sleep(200);
                        Task3();
                        ContinueOrNo();
                        break;
                    case 4:
                        Task4();
                        // Thread.Sleep(200);
                        ContinueOrNo();
                        break;
                    case 5:
                        Task5();
                        ContinueOrNo();
                        break;
                    case 6:
                        Task6();
                        ContinueOrNo();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Произошла ошибка. Проверьте введённые Вами данные и попробуйте еще раз.");
                        break;
                }

            }
        }
            public static void ContinueOrNo()
            {
                Console.WriteLine("Если хотите продолжить работу с программой, нажмите любую кнопку.");
                Console.ReadKey();
                Console.Clear();
                Begin();
            }
            public static void MaxLenNumber(string number1, string number2, string znak)
        {
            int maxLen = Math.Max(number1.Length, number2.Length);

            switch (znak)
            {
                case "+":
                    if (maxLen == number1.Length)
                    {
                        for (int i = 0; i <= maxLen - number2.Length; i++) number2 = " " + number2;
                        Console.WriteLine("Для лучшего понимания вычисления, перенесем число с большим числом разрядов выше.");
                        Console.WriteLine("Выстроим числа в столбик и будем складывать каждый разряд по отдельности.\n");
                        Console.WriteLine($" {number1}\n+\n {getOffset(number1,number2)+number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    else
                    {
                        for (int i = 0; i <= maxLen - number1.Length; i++) number1 = " " + number1;
                        Console.WriteLine("Для лучшего понимания вычисления, перенесем число с большим числом разрядов выше.");
                        Console.WriteLine("Выстроим числа в столбик и будем складывать каждый разряд по отдельности.\n");
                        Console.WriteLine($" {number2}\n+\n {getOffset(number1,number2)+number1}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    break;
                case "-":
                    if (maxLen == number1.Length)
                    {
                        for (int i = 0; i <= maxLen - number2.Length; i++) number2 = " " + number2;
                        Console.WriteLine("Выстроим числа в столбик, и будем вычитать каждый разряд по отдельности.\n");
                        Console.WriteLine($" {number1}\n-\n {getOffset(number1,number2)+number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    else
                    {
                        for (int i = 0; i <= maxLen - number1.Length; i++) number1 = " " + number1;
                        Console.WriteLine("Выстроим числа в столбик, и будем вычитать каждый разряд по отдельности.\n");
                        Console.WriteLine($" {number1}\n-\n {getOffset(number1,number2)+number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    break;
                case "*":
                    if (maxLen == number1.Length)
                    {
                        for (int i = 0; i <= maxLen - number2.Length; i++) number2 = " " + number2;
                        Console.WriteLine("Для лучшего понимания вычисления, перенесем число с большим числом разрядов выше.");
                        Console.WriteLine("Выстроим числа в столбик, и будем умножать каждый разряд по отдельности.\n");
                        Console.WriteLine($" {number1}\n*\n {getOffset(number1,number2)+number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    else
                    {
                        for (int i = 0; i <= maxLen - number1.Length; i++) number1 = " " + number1;
                        Console.WriteLine("Для лучшего понимания вычисления, перенесем число с большим числом разрядов выше.");
                        Console.WriteLine("Выстроим числа в столбик, и будем умножать каждый разряд по отдельности.\n");
                        Console.WriteLine($" {number2}\n*\n {getOffset(number1,number2)+number1}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }
                    break;
                default:
                    throw new ArgumentException("");
                    break;
            }
        }
            public static void Task1()
        {
            Console.WriteLine("\n\n");
            Console.Write("Введите систему счисления, из которой нужно перевести: ");
            int system1 = int.Parse(Console.ReadLine());
            Console.Write("Введите число: ");
            string value1 = Console.ReadLine();

            Console.Write("Введите систему счисления, в которую нужно перевести: ");
            int system2 = int.Parse(Console.ReadLine());
            
            Number number1 = new Number(value1, system1);
            
            Console.WriteLine("Результат выполнения: " + ConvertNotation(number1, system2).Value);
            
        }

        public static void Task2()
        {
            Console.WriteLine("Введите любое целое число (до 5000 включительно):");
            if (uint.TryParse(Console.ReadLine(), out uint number))
                Console.WriteLine(ToRoman(number));
            else
                Console.WriteLine("Проверьте введённые данные и повторите попытку еще раз.");
        }

        public static void Task3()
        {
            Console.WriteLine("Введите римское число: ");
            string input = Console.ReadLine();
            Console.WriteLine(FromRoman(input));
        }
        public static List<int> ParseStringToList(string numberInput)
        {
            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";
            List<int> number = new List<int>();

            for (int i = 0; i < numberInput.Length; i++)
            {
                if (numbers.Contains(numberInput[i].ToString())) number.Add(numberInput[i] - '0');
                if (lettersUpper.Contains(numberInput[i].ToString())) number.Add(lettersUpper.IndexOf(numberInput[i]) + 10);
                if (lettersLower.Contains(numberInput[i].ToString())) number.Add(lettersLower.IndexOf(numberInput[i]) + 36);
            }

            return number;
        }
        
       public static void Task4()
        {
            Console.WriteLine("Введите систему счисления от 1 до 50.");
            string numberSystemInput = Console.ReadLine();
            if (!int.TryParse(numberSystemInput, out int numberSystem) || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Система счисления введена некорректно");
            Console.WriteLine("Введите первое число.");
            string number1Input = Console.ReadLine();
            Console.WriteLine("Введите второе число.");
            string number2Input = Console.ReadLine();
            Console.WriteLine("\n");

            List<int> number1 = new List<int>();
            List<int> number2 = new List<int>();

            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            for (int i = 0; i < number1Input.Length; i++)
            {
                if (!numbers.Contains(number1Input[i].ToString()) && !lettersUpper.Contains(number1Input[i].ToString()) && !lettersLower.Contains(number1Input[i].ToString()))
                    throw new ArgumentException("Числа (или одно из них) введены неверно.");
            }

            for (int i = 0; i < number2Input.Length; i++)
            {
                if (!numbers.Contains(number2Input[i].ToString()) && !lettersUpper.Contains(number2Input[i].ToString()) && !lettersLower.Contains(number2Input[i].ToString()))
                    throw new ArgumentException("Числа (или одно из них) введены неверно.");
            }

            number1 = ParseStringToList(number1Input);
            number2 = ParseStringToList(number2Input);

            bool foolTest1 = false;
            bool foolTest2 = false;
            for (int i = 0; i < number1.Count; i++)
            {
                if (number1[i] >= numberSystem) foolTest1 = true;
                if (foolTest1)
                    throw new ArgumentException("Числа (или одно из них) введены неверно.");
            }

            for (int i = 0; i < number2.Count; i++)
            {
                if (number2[i] >= numberSystem) foolTest2 = true;
                if (foolTest2)
                    throw new ArgumentException("Числа (или одно из них) введены неверно.");
            }

            int maxLen = Math.Max(number1.Count, number2.Count);

            if (number1.Count < maxLen)
            {
                number1.Reverse();
                for (int i = 0; i < maxLen - number1Input.Length; i++) number1.Add(0);
                number1.Reverse();
            }
            if (number2.Count < maxLen)
            {
                number2.Reverse();
                for (int i = 0; i < maxLen - number2Input.Length; i++) number2.Add(0);
                number2.Reverse();
            }

            MaxLenNumber(number1Input, number2Input, "+");

            int excess = 0;
            List<int> result = new List<int>();

            for (int i = (maxLen - 1); i > -1; i--)
            {
                int sumRes = number1[i] + number2[i];
                if (sumRes >= numberSystem)
                {
                    result.Add(sumRes % numberSystem + excess);
                    excess = sumRes / numberSystem;
                }

                else result.Add(sumRes + excess);
                excess = sumRes / numberSystem;
            }

            if (excess > 0)
            {
                if (excess >= 1 && excess <= 9) result.Add(excess);
                if (excess >= 10 && excess <= 35) result.Add(lettersUpper[excess - 10]);
                if (excess >= 36) result.Add(lettersLower[excess - 36]);
            }

            string Output = "";
            result.Reverse();

            foreach (int item in result)
            {
                if (item >= 0 && item <= 9) Output += item;
                if (item >= 10 && item <= 35) Output += lettersUpper[item - 10];
                if (item >= 36) Output += lettersLower[item - 36];
            }

            Console.WriteLine(" " + Output);
            Console.WriteLine($"В результате получаем, что {number1Input} + {number2Input} = {Output} в {numberSystem}-ной системе счисления.");
        }
       
       public static void Task5()
       {
            Console.WriteLine("Введите систему счисления от 1 до 50.");
            string numberSystemInput = Console.ReadLine();
            bool foolTest = int.TryParse(numberSystemInput, out int numberSystem);
            if (!foolTest || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Система счисления введена некорректно.");
            Console.WriteLine("Введите первое число.");
            string number1Input = Console.ReadLine();
            Console.WriteLine("Введите второе число.");
            string number2Input = Console.ReadLine();

            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            List<int> number1 = new List<int>();
            List<int> number2 = new List<int>();

            for (int i = 0; i < number1Input.Length; i++)
            {
                if (!numbers.Contains(number1Input[i].ToString()) && !lettersUpper.Contains(number1Input[i].ToString()) && !lettersLower.Contains(number1Input[i].ToString()))
                    throw new ArgumentException("Числа (или одно из них) введены неверно.");
            }

            for (int i = 0; i < number2Input.Length; i++)
            {
                if (!numbers.Contains(number2Input[i].ToString()) && !lettersUpper.Contains(number2Input[i].ToString()) && !lettersLower.Contains(number2Input[i].ToString()))
                    throw new ArgumentException("Числа (или одно из них) введены неверно.");
            }

            number1 = ParseStringToList(number1Input);
            number2 = ParseStringToList(number2Input);

            string Test1 = "";
            string Test2 = "";

            for (int i = 0; i < number1.Count; i++) Test1 += number1[i].ToString();
            for (int i = 0; i < number2.Count; i++) Test2 += number2[i].ToString();

            bool minus;

            if (int.Parse(Test1) >= (int.Parse(Test2))) minus = false;
            else minus = true;

            int maxLen = Math.Max(number1.Count, number2.Count);

            if (number1.Count < maxLen)
            {
                number1.Reverse();
                for (int i = 0; i < maxLen - number1Input.Length; i++) number1.Add(0);
                number1.Reverse();
            }

            if (number2.Count < maxLen)
            {
                number2.Reverse();
                for (int i = 0; i < maxLen - number2Input.Length; i++) number2.Add(0);
                number2.Reverse();
            }

            MaxLenNumber(number1Input, number2Input, "-");

            List<int> result = new List<int>();

            if (!minus)
            {
                for (int i = maxLen - 1; i >= 0; i--)
                {
                    if (number1[i] >= number2[i]) result.Add(number1[i] - number2[i]);
                    else
                    {
                        number1[i - 1] -= 1;
                        number1[i] += numberSystem;
                        result.Add(number1[i] - number2[i]);
                    }
                }
                string programOutput = "";
                result.Reverse();
                foreach (int item in result)
                {
                    if (item >= 0 && item <= 9) programOutput += item.ToString();
                    if (item >= 10 && item <= 35) programOutput += lettersUpper[item - 10];
                    if (item >= 36) programOutput += lettersLower[item - 36];
                }

                for (int i = 0; i < programOutput.Length; i++)
                {
                    if (programOutput[i] == '0')
                    {
                        programOutput = programOutput.Remove(i, 1);
                        programOutput = " " + programOutput;
                    }
                    else break;
                }

                Console.WriteLine(" " + programOutput);
                Console.WriteLine($"В результате получим {number1Input} - {number2Input} = {programOutput} в {numberSystem}-ой системе счисления.");
            }

            else
            {
                for (int i = maxLen - 1; i >= 0; i--)
                {
                    if (number2[i] >= number1[i]) result.Add(number2[i] - number1[i]);
                    else
                    {
                        number2[i - 1] -= 1;
                        number2[i] += numberSystem;
                        result.Add(number2[i] - number1[i]);
                    }

                }

                string programOutput = "";
                result.Reverse();
                foreach (int item in result)
                {
                    if (item >= 0 && item <= 9) programOutput += item.ToString();
                    if (item >= 10 && item <= 35) programOutput += lettersUpper[item - 10];
                    if (item >= 36) programOutput += lettersLower[item - 36];
                }

                for (int i = 0; i < programOutput.Length; i++)
                {
                    if (programOutput[i] == '0')
                    {
                        programOutput = programOutput.Remove(i, 1);
                    }
                    else break;
                }

                programOutput = "-" + programOutput;
                Console.WriteLine(" " + programOutput);
                Console.WriteLine($"В результате получим {number1Input} - {number2Input} = {programOutput} в {numberSystem}-ой системе счисления.");
            }

        }
       public static void Task6()
        {
            Console.WriteLine("Введите систему счисления от 1 до 50.");
            string numberSystemInput = Console.ReadLine();
            if (!int.TryParse(numberSystemInput, out int numberSystem) || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Основание системы счисления введена не корректно.");
            Console.WriteLine("Введите первый множитель.");
            string number1Input = Console.ReadLine();
            Console.WriteLine("Введите второй множитель.");
            string number2Input = Console.ReadLine();

            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            for (int i = 0; i < number1Input.Length; i++)
            {
                if (!numbers.Contains(number1Input[i]) && !lettersUpper.Contains(number1Input[i]) && !lettersLower.Contains(number1Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            for (int i = 0; i < number2Input.Length; i++)
            {
                if (!numbers.Contains(number2Input[i]) && !lettersUpper.Contains(number2Input[i]) && !lettersLower.Contains(number2Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            List<int> number1 = new List<int>();
            List<int> number2 = new List<int>();

            number1 = ParseStringToList(number1Input);
            number2 = ParseStringToList(number2Input);

            int maxLen = Math.Max(number1.Count, number2.Count);
            MaxLenNumber(number1Input, number2Input, "*");

            List<int> result = new List<int>();
            int overage = 0;
            for (int i = number2.Count - 1; i >= 0; i--)
            {
                for (int j = number1.Count - 1; j >= 0; j--)
                {
                    int midterm = number1[j] * number2[i];
                    if (midterm >= numberSystem)
                    {
                        result.Add(midterm % numberSystem + overage);
                        overage = midterm / numberSystem;
                    }
                    else result.Add(midterm + overage);
                    overage = midterm / numberSystem;
                }

            }

            if (overage > 0)
            {
                if (overage >= 1 && overage <= 9) result.Add(overage);
                if (overage >= 10 && overage <= 35) result.Add(lettersUpper[overage - 10]);
                if (overage >= 36) result.Add(lettersLower[overage - 36]);
            }

            result.Reverse();
            string programOutput = "";
            foreach (int e in result)
            {
                if (e >= 0 && e <= 9) programOutput += e;
                if (e >= 10 && e <= 35) programOutput += lettersUpper[e - 10];
                if (e >= 36) programOutput += lettersLower[e - 36];
            }

            Console.WriteLine(programOutput);
            Console.WriteLine($"В результате получаем, что {number1Input} * {number2Input} = {programOutput} в {numberSystem}-тичной системе счисления.");
        }

//-----------------------------------------------------------------------------------------------------------------/
        static string getOffset(string number1Input, string number2Input)
        {
            int diff = number1Input.ToString().Length - number2Input.ToString().Length;
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
        //
        // static string getResultOffset(int num1, string result)
        // {
        //     int offsetLength = 2 + num1.ToString().Length;
        //     offsetLength -= result.Length;
        //     string offset = "";
        //     for (int i = 0; i < offsetLength; i++)
        //     {
        //         offset += " ";
        //     }
        //
        //     return offset;
        // }


        static int FromAnyToDec(string number, int baze) {
            if (baze > 50)
                throw new ArgumentException("Основание системы счисление должно быть меньше или равно 50");
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
                throw new ArgumentException("Основание системы счисления должно быть меньше или равно 50");
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
            throw new ArgumentException("Неверный ввод");
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
                Thread.Sleep(1000);
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
                    }
                }
            }
            return sum;
        }
    }
}