using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ExtensionMethods
{
    public static class StringExtension
    {
        public static void WriteStrInSpecialPlace(this string str, int posX, int posY) 
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(str);
        }   
        
        public static void CleanStrInSpecialPlace(this string str, int posX, int posY) 
        {
            char[] forRemove = str.ToCharArray();
            for (int i = 0; i < forRemove.Length; i++)
            {
                forRemove[i] = PointConst.EmptySpace;
            }

            string empty = new string(forRemove);

            Console.SetCursorPosition(posX, posY);

            Console.WriteLine(empty);
        }
    }
}
