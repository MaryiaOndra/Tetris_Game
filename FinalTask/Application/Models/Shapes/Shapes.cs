using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Shapes
{
    abstract class Shapes
    {
        protected int x = PlayFieldConst.BorderXPos + PlayFieldConst.FieldWidth / 2;
        protected int y = PlayFieldConst.BorderYPos;
        protected char ch = 'M';

        abstract internal void CreateShape();
        protected void ChooseRandomChar() 
        {
            Random random = new Random();
            ch = Convert.ToChar(random.Next(0, 22) + 65);

            //TODO: impruve changing color
            //int color = random.Next(9, 11);
            //switch (color)
            //{
            //    case (int)ConsoleColor.Green:
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        break;             
            //    case (int)ConsoleColor.Cyan:
            //        Console.ForegroundColor = ConsoleColor.Cyan;
            //        break;         
            //    case (int)ConsoleColor.Blue:
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //        break;
            //}
        }
    }
}
