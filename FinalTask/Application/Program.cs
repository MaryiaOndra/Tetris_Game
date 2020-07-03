using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {


            Point point = new Point(20, 30);

            Console.SetBufferSize(150, 9000);
            
            char newChar = '\u2665';


            Console.WriteLine(newChar);

            Console.Read();
        }
    }
}
