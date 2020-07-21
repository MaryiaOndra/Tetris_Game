using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    class GameWindow
    {
        public GameWindow()
        {
            SetBufferSize();
        }
                
        public void SetBufferSize() 
        {
            Console.SetBufferSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
        }
    }
}
