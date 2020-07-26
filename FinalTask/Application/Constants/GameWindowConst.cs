using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class BlockConst 
    {
        public const int StartX = PlayFieldConst.BorderXPos + PlayFieldConst.FieldWidth / 2;
        public const int StartY = PlayFieldConst.BorderYPos;
        public const int StartChar = 65; 
        public const int RangeChar = 22; 
    }

    public static class PointConst 
    {
        public const char EmptySpace = ' ';
    }
    public static class GameWindowConst
    {
        public const int WindowWidth = 60;
        public const int WindowHeight = 30;
    }

    public static class PlayFieldConst
    {
        public const char SymBorder = '#';
        public const int BorderXPos = (GameWindowConst.WindowWidth - FieldWidth) / 2;
        public const int BorderYPos = 1;
        public const int FieldWidth = 18;
        public const int FieldHeight = 20;
    }    
}
