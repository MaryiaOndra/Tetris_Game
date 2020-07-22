using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Models
{
    class Tetromino
    {
        private string[] _tetrominoBlock;

        public Tetromino()
        {

        }

        public void GetTetrominoArray() 
        {
            string[] tetrominoBlock = new string[7];

            tetrominoBlock[0] = "..X...X...X...X.";
            tetrominoBlock[1] = "..X..XX...X.....";
            tetrominoBlock[2] = ".....XX..XX.....";
            tetrominoBlock[3] = "..X..XX..X......";
            tetrominoBlock[4] = ".X...XX...X.....";
            tetrominoBlock[5] = ".X...X...XX.....";
            tetrominoBlock[6] = "..X...X..XX.....";

            _tetrominoBlock = tetrominoBlock;
        }


        private string[] _t;
        public void Shape() 
        {
            string[] tet = 
                {"  X ",
                 "  X ",
                 "  X ",
                 "  X ",
            };

            int pos = tet[0].IndexOf('X');
            _t = tet;
        }

        public void DrawTetromino2()
        {
            Shape();
            foreach (var item in _t)
            {
                Console.WriteLine(item);
            }
        }

        public void DrawTetromino() 
        {
            GetTetrominoArray();

            int currentBlock = new Random().Next(0, _tetrominoBlock.Length - 1);

            Console.SetCursorPosition(PlayFieldConst.BorderXPos, PlayFieldConst.BorderYPos);

            Console.WriteLine(_tetrominoBlock[currentBlock]);
         
        }

        public int Rotate(int posX, int posY, int rotation) 
        {
            int pi = 0;

            switch (rotation % 4)
            {
                case 0: // 0 degrees
                    pi = posX * 4 + posY;
                    break;

                case 1: // 90 degrees
                    pi = 12 + posY - (posY * 4);
                    break;

                case 2: //180 degrees
                    pi = 15 - (posY * 4) - posX;
                    break;

                case 3: //270 degree
                    pi = 3 - posY + (posX * 4);
                    break;


                default:
                    break;
            }

            return pi;
        }
    }
}
