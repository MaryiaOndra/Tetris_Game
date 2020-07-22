using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    class PlayField
    {
        static private int posX = PlayFieldConst.BorderXPos;
        static private int posY = PlayFieldConst.BorderYPos;

        public void DrawPlayField() 
        {
            DrawVerticalLine(posX, posY);
            DrawHorizontalLine(posX, PlayFieldConst.FieldHeight);
            DrawVerticalLine(posX + PlayFieldConst.FieldWidth, posY);
        }

        public void DrawVerticalLine(int posX, int posY) 
        {
            char[] verticalLine = new char[PlayFieldConst.FieldHeight];

            for (int i = 0; i < verticalLine.Length; i++)
            {
                Console.SetCursorPosition(posX, posY);
                verticalLine[i] = PlayFieldConst.SymBorder;
                Console.WriteLine(verticalLine[i]);
                posY++;
            }
            posY = default;
        }

        public void DrawHorizontalLine(int posX, int posY) 
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(new string(PlayFieldConst.SymBorder, PlayFieldConst.FieldWidth + 1));            
        }
    }
}
