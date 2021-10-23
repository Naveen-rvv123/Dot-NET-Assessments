using System;

namespace DelegateDemoMastek
{
    //1
    delegate int CalculatoDelegate(int first, int second);

    class Program
    {
        //2
        static int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }
        static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        static void Main(string[] args)
        {

            //3 delegate instance - points to method
            CalculatoDelegate demo1 = AddNumbers;
            CalculatoDelegate demo2 = Multiply;

            //4 invoke
            int result = demo1(4, 6);
            Console.WriteLine("Addition :" + result);
            int result1 = demo2(8, 9);
            Console.WriteLine("Multiply:" + result1);
            //Multiplication
          
            Console.WriteLine("Hello World!");
            Console.WriteLine("-----------------------");


            // lambda
            CalculatoDelegate demo3 = (a, b) => a + b;
            result = demo3(2, 4);
            Console.WriteLine("Addition =" + result);

            //lambda
           // CalculatoDelegate
                demo3 = (x, y) => x - y;
            result = demo3(3, 5);
            Console.WriteLine("minu=" + result);
           // CalculatoDelegate
           demo3 = (c, d) => c * d;
            result = demo3(5, 6);
            Console.WriteLine("Mult =" + result);


            //
        }
    }
}
