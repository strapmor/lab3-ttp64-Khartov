namespace lab3_ttp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task0();
        }

        // Задание 0
        static void Task0()
        {
            Console.Write("Задание 0. Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Max = {Max2(a, b)}, Min = {Min2(a, b)}");
        }

        static int Max2(int a, int b)
        {
            return a > b ? a : b;
        }

        static int Min2(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
