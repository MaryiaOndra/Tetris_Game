using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application.Models
{
    sealed class PlayField
    {
        private int posX = PlayFieldConst.BorderXPos;
        private int posY = PlayFieldConst.BorderYPos;
        private char fieldChar = PlayFieldConst.SymBorder;

        public Point[] RightSide { get; private set; }
        public Point[] LeftSide { get; private set; }
        public Point[] BottomSide { get; private set; }
        public Point[][] PlayFieldPoints { get; internal set; }

        public PlayField()
        {
            DrawLeftSide();

            DrawRightSide();

            DrawBottomSide();
        }

        internal void DrawLeftSide()
        {
            LeftSide = new Point[PlayFieldConst.FieldHeight];

            for (int i = 0; i < PlayFieldConst.FieldHeight; i++)
            {
                LeftSide[i] = new Point(posX, posY, fieldChar);
                LeftSide[i].DrawPoint();
                posY++;
            }

            posX = PlayFieldConst.BorderXPos;
            posY = PlayFieldConst.BorderYPos;
        }

        internal void DrawRightSide()
        {
            RightSide = new Point[PlayFieldConst.FieldHeight];

            for (int i = 0; i < PlayFieldConst.FieldHeight; i++)
            {
                RightSide[i] = new Point((posX + PlayFieldConst.FieldWidth), posY, fieldChar);
                RightSide[i].DrawPoint();
                posY++;
            }

            posX = PlayFieldConst.BorderXPos;
            posY = PlayFieldConst.BorderYPos;
        }

        internal void DrawBottomSide()
        {
            BottomSide = new Point[PlayFieldConst.FieldWidth + 1];

            for (int i = 0; i < PlayFieldConst.FieldWidth + 1; i++)
            {
                BottomSide[i] = new Point(posX, (posY + PlayFieldConst.FieldHeight), fieldChar);
                BottomSide[i].DrawPoint();
                posX++;
            }

            posX = PlayFieldConst.BorderXPos;
            posY = PlayFieldConst.BorderYPos;
        }

        internal void CreateListOfFieldPoints()
        {
            Point[][] points = new Point[PlayFieldConst.FieldHeight][];
            Point startP = new Point(posX + 1, posY, ' ');

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point[PlayFieldConst.FieldWidth];

                for (int j = 0; j < points[i].Length; j++)
                {
                    points[i][j] = new Point(startP.X + j, startP.Y + i, ' ');
                }
            }

            PlayFieldPoints = points;
        }

        //TODO: create nice frames : Console.WriteLine('╦');
        //char[] vs = { '║', '║', '║', '║', '║' };
    }
}
