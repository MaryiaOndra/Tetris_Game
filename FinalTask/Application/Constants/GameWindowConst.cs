using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class ScoreTable 
    {
        public const string Name = "Name of player:";
        public const string Score = "Score:";
    }
    public static class LogConst 
    {
        public const string StartLog = "Start game";
        public const string FinishLog = "Finish game";
        public const string Increase = "Increase difficulty and speed";
    }
    public static class TetrisGameConst 
    {
        public const int posYPause = 23;
        public const string Pause = "# Pause is active, to diactivate press 'P' #";
    }

    public static class BlockConst 
    {
        public const int StartX = PlayFieldConst.BorderXPos + PlayFieldConst.FieldWidth / 2;
        public const int StartY = PlayFieldConst.BorderYPos;
        public const int StartNumChar = 65; 
        public const int RangeChar = 22; 
    }

    public static class PointConst 
    {
        public const char EmptySpace = ' ';
    }

    public static class GameWindowConst
    {
        public const string Greeting = "*****TETRIS GAME*****";
        public const string Greeting2 = @"
        .___________. _______ .___________..______       __       _______.
        |           ||   ____||           ||   _  \     |  |     /       |
        `---|  |----`|  |__   `---|  |----`|  |_)  |    |  |    |   (----`
            |  |     |   __|      |  |     |      /     |  |     \   \    
            |  |     |  |____     |  |     |  |\  \----.|  | .----)   |   
            |__|     |_______|    |__|     | _| `._____||__| |_______/    
                                                                          ";
        public const string PressEnter = "press ENTER to start the game";
        public const string Thanks = "Thank you for playing!";
        public const string EnterName = "Please enter your name: ";
        public const string WantTryAgain = "Do you want to try one more time? Y/N";
        public const string ChooseShortName = "Please choose name shorter";

        public const int LeftCursorPos = WindowWidth / 2;
        public const int TopCursorPos = WindowHeight / 2;
        public const int WindowWidth = 80;
        public const int WindowHeight = 25;
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
