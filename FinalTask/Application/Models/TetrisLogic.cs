using Application.Enums;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application.Models
{
    sealed class TetrisLogic
    {

        private List<Point> workTetromino;
        private Direction direction;
        int angle = 90;
 
        public TetrisLogic()
        {

        }

        public void GameLoop() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            SetRandomShape();

            while (true)
            {
                for (int i = workTetromino.Count - 1; i >= 0; i--)
                {
                    workTetromino[i].DropDown();
                }

                Thread.Sleep(100);
            }
        }

        public void Action()
        {
            switch (direction)
            {
                case Direction.Up:
                    RotateShape(angle);
                    break;

                case Direction.Down:
                    //TODO add dropping a figure with more speed
                    break;

                case Direction.Left:
                    for (int i = 0; i < workTetromino.Capacity; i++)
                    {
                        workTetromino[i].MoveLeft();
                    }
                    break;

                case Direction.Right:
                    for (int i = 0; i < workTetromino.Capacity; i++)
                    {
                        workTetromino[i].MoveRight();
                    }
                    break;

                default:
                    for (int i = 0; i < workTetromino.Capacity; i++)
                    {
                        workTetromino[i].DropDown();
                    }
                    break;
            }
        }

        private void SetRandomShape()
        {
            Random r = new Random();
            int numShape = r.Next(0, 6);

            switch (numShape)
            {
                case (int)TetrominoNames.O:
                    OShape o = new OShape();
                    workTetromino = o.NewTetr;
                    break;

                case (int)TetrominoNames.I:
                    ShapeI i = new ShapeI();
                    workTetromino = i.NewTetr;
                    break;

                case (int)TetrominoNames.J:
                    JShape j = new JShape();
                    workTetromino = j.NewTetr;
                    break;

                case (int)TetrominoNames.T:
                    TShape t= new TShape();
                    workTetromino = t.NewTetr;
                    break;

                case (int)TetrominoNames.L:
                    LShape l = new LShape();
                    workTetromino = l.NewTetr;
                    break;

                case (int)TetrominoNames.S:
                    SShape s = new SShape();
                    workTetromino = s.NewTetr;
                    break;

                case (int)TetrominoNames.Z:
                    ZShape z = new ZShape();
                    workTetromino = z.NewTetr;
                    break;
            }
        }

        public void GetDirection(ConsoleKey consoleKey) 
        {       
            switch (consoleKey)
            {   
                //TODO Add Keys: Space(pause), Esc(cancel) 
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;                    
            }           
        }

        private void RotateShape(int angle)
        {
            List<Point> newTetromino = new List<Point> { };

            for (int i = 0; i < workTetromino.Count; i++)
            {
                int newX = workTetromino[i].X * Convert.ToInt32(Math.Cos(angle)) - workTetromino[i].Y * Convert.ToInt32(Math.Sin(angle));
                int newY = workTetromino[i].X * Convert.ToInt32(Math.Sin(angle)) + workTetromino[i].Y * Convert.ToInt32(Math.Cos(angle));

                newTetromino.Add(new Point(newX, newY, workTetromino[i].Char));
            }

            switch (IsCollision(newTetromino))
            {
                case true:
                    break;

                case false:
                    for (int i = 0; i < workTetromino.Count; i++)
                    {
                        workTetromino[i].Clear();
                    }

                    foreach (Point p in newTetromino)
                    {
                        p.DrawPoint();
                    }
                    workTetromino = newTetromino;
                    break;
            }
        }

        private bool IsCollision(List<Point> checkingList)
        {
            bool answer = true;

            foreach (Point p in checkingList)
            {
                if (p.Char.Equals(' ') || p.X < 0 || p.Y < 0)
                {
                    answer = true;
                }
                else
                    answer = false;
            }

            return answer;
        }

        private static bool GameOver()
        {
            return false;
        }

    }
}

