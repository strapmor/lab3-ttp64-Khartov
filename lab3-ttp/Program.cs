namespace lab3_ttp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task0();
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();

            Console.ReadKey();
        }

        // Задание 0
        static void Task0()
        {
            Console.Write("Задание 0. Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Max = {Max2(a, b)}, Min = {Min2(a, b)}");
            Console.WriteLine();
        }

        static int Max2(int a, int b)
        {
            return a > b ? a : b;
        } 

        static int Min2(int a, int b)
        {
            return a < b ? a : b;
        }

        public static string GetStats(params int[] numbers)
        {
            return $"Кол-во:\t\t{numbers.Length};\n" +
                $"Сумма:\t\t{Math.Round((double)numbers.Sum(), 2)};\n" +
                $"Ср. ариф:\t{Math.Round(numbers.Average(), 2)};\n" +
                $"Макс:\t\t{numbers.Max()};\n" +
                $"Мин:\t\t{numbers.Min()};";

        }
        
        public static string GetStats(params double[] numbers)
        {
            return $"Кол-во:\t\t{numbers.Length};\n" +
                $"Сумма:\t\t{Math.Round(numbers.Sum(), 2)};\n" +
                $"Ср. ариф:\t{Math.Round(numbers.Average(), 2)};\n" +
                $"Макс:\t\t{numbers.Max()};\n" +
                $"Мин:\t\t{numbers.Min()};";
        }

        static void Task1()
        {
            // Задание 1
            Console.WriteLine("Задание 1");
            Console.WriteLine("GetStats(1, 2, 3)");
            Console.WriteLine(GetStats(1, 2, 3));

            Console.WriteLine("\nGetStats(10, 20, 30, 40, 50)");
            Console.WriteLine(GetStats(10, 20, 30, 40, 50));

            Console.WriteLine("\nGetStats(1.1, 2.2, -5.5)");
            Console.WriteLine(GetStats(1.1, 2.2, -5.5));

            Console.WriteLine();
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a; 
            a = b; 
            b = temp;
        }

        public static void Reverse(ref int[] arr)
        {
            // метод двух указателей
            int left = 0, right = arr.Length - 1;
            while(left < right)
            {
                // Меняем местами значения элементов
                //(arr[left], arr[right]) = (arr[right], arr[left]);
                Swap(ref arr[left], ref arr[right]);
                left++;
                right--;
            }
        }

        public static int[] Reverse(int[] arr)
        {
            int[] inverted = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                inverted[arr.Length - i - 1] = arr[i];
            }
            return inverted;
        }

        static void Task2()
        {
            // Задание 2
            Console.WriteLine("Задание 2");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.Write("Исходный массив (arr):\t");
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            Reverse(ref arr);
            Console.Write("Развёрнутый массив (arr):\t");
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            int[] reversed = Reverse(arr);
            Console.Write("Развёрнутый массив (reversed):\t");
            foreach (int i in reversed)
                Console.Write($"{i} ");
            Console.WriteLine("\n");
        }

        public static bool TryFind(int[] array, int value, out int index)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == value)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        static void Task3()
        {
            // Задание 3
            Console.WriteLine("Задание 3");
            int[] arr = { 1, 2, 3, 4 };
            int[] testData = { 2, 10 };

            foreach(int i in testData)
            {
                Console.WriteLine($"Попытка найти {i} в массиве");
                if (TryFind(arr, i, out int index))
                {
                    Console.WriteLine($"Индекс: {index}");
                    Console.WriteLine("Успех!");
                }
                else
                    Console.WriteLine("Неудача!");
            }
            Console.WriteLine();
        }

        public delegate bool FilterCondition(int number);

        public static int[] Filter(int[] sourceArray, FilterCondition condition)
        {
            int[] result = new int[1];
            int i = 0;
            foreach (int elem in sourceArray) 
            {
                if (condition(elem))
                {
                    if(i >= result.Length)
                    {
                        Array.Resize(ref result, result.Length+1);
                    }
                    result[i] = elem;
                    i++;
                }

            }
            return result;
        }

        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        public static bool IsPositive(int n)
        {
            return n > 0;
        }

        public static bool IsMoreThanByteMax(int n)
        {
            return n > byte.MaxValue;
        }

        static void PrintArr(string message, int[] arr)
        {
            Console.Write(message);
            foreach(int i in arr) 
                Console.Write($" {i}");
            Console.WriteLine();
        }

        static void Task4()
        {
            Console.WriteLine("Задание 4");
            int[] arr = { 0, 1, 256, -2, -3 };
            int[] res1 = Filter(arr, IsEven);
            int[] res2 = Filter(arr, IsPositive);
            int[] res3 = Filter(arr, IsMoreThanByteMax);

            PrintArr("Исходный массив:", arr);
            PrintArr("Фильтр чётных:", res1);
            PrintArr("Фильтр положительных:", res2);
            PrintArr("Фильтр больше 255:", res3);
            Console.WriteLine();
        }

        static void AddItem(ref int[] arr, int item)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = item;
        }

        static int[] AddItem(int[] arr, int item)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = item;
            return arr;
        }

        static void Task5()
        {
            int[] array = { 1, 2, 3 };

            Console.WriteLine("--- ЭКСПЕРИМЕНТ 1: Попытка изменить ссылку БЕЗ ref ---");
            Console.WriteLine($"Массив ДО вызова: [{string.Join(", ", array)}]. Хэш-код: {array.GetHashCode()}");

            // Вызываем метод, который должен был бы подменить массив, но не сможет
            AddItem(array, 4);
            Console.WriteLine($"Массив ПОСЛЕ вызова: [{string.Join(",", array)}]. Хэш-код: {array.GetHashCode()}");
            Console.WriteLine("ОЖИДАНИЕ: Массив должен был измениться. РЕАЛЬНОСТЬ: Он не изменился.\n");
            Console.WriteLine("--- ЭКСПЕРИМЕНТ 2: Изменение ссылки с помощью ref ---");
            Console.WriteLine($"Массив ДО вызова: [{string.Join(", ", array)}]. Хэш-код: {array.GetHashCode()}");

            // А вот этот вызов сработает как надо
            AddItem(ref array, 4);
            Console.WriteLine($"Массив ПОСЛЕ вызова: [{string.Join(",", array)}]. Хэш-код: {array.GetHashCode()}");
            Console.WriteLine("ОЖИДАНИЕ: Массив изменился. РЕАЛЬНОСТЬ: Успех!\n");

            Console.WriteLine("--- ЭКСПЕРИМЕНТ 3: Изменение массива по значению ---");
            array = AddItem(array, 5);
            Console.WriteLine($"Массив ПОСЛЕ вызова: [{string.Join(",", array)}]. Хэш-код: {array.GetHashCode()}");
            Console.WriteLine("ОЖИДАНИЕ: Массив изменился. РЕАЛЬНОСТЬ: Успех!\n");
        }
    }
}
