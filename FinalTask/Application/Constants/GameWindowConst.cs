using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class GameWindowConst
    {
        public const int WindowWidth = 120;
        public const int WindowHeight = 30;
    }

    public static class PlayFieldConst
    {
        public const char SymBorder = '#';
        public const int BorderXPos = (GameWindowConst.WindowWidth - FieldWidth) / 2;
        public const int BorderYPos = 0;
        public const int FieldWidth = 30;
        public const int FieldHeight = 20;
    }
}
