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
        public const int BorderXPos = GameWindowConst.WindowWidth / 4;
        public const int BorderYPos = 0;
    }
}
