using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    class GameWindow
    {
        public GameWindow()
        {
            SetWindowParameters();
        }
                
        public void SetWindowParameters() 
        {
            Console.SetWindowSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
            Console.SetBufferSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
            //Console.CursorVisible = false;
        }
    }
}
