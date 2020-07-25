using Application.Enums;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Models
{
    sealed class TetrisLogic
    {

        private List<Point> WorkTetromino;
        private Direction direction;
        int angle = 90;
 
        public TetrisLogic()
        {
            SetRandomShape();
        }

        public static void Loop() 
        {
            
        
        }

        public void Action(List<Point> points)
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
                    for (int i = 0; i < points.Capacity; i++)
                    {
                        points[i].MoveLeft();
                    }
                    break;

                case Direction.Right:
                    for (int i = 0; i < points.Capacity; i++)
                    {
                        points[i].MoveRight();
                    }
                    break;

                default:
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
                    WorkTetromino = o.NewTetr;
                    break;

                case (int)TetrominoNames.I:
                    ShapeI i = new ShapeI();
                    WorkTetromino = i.NewTetr;
                    break;

                case (int)TetrominoNames.J:
                    JShape j = new JShape();
                    WorkTetromino = j.NewTetr;
                    break;

                case (int)TetrominoNames.T:
                    TShape t= new TShape();
                    WorkTetromino = t.NewTetr;
                    break;

                case (int)TetrominoNames.L:
                    LShape l = new LShape();
                    WorkTetromino = l.NewTetr;
                    break;

                case (int)TetrominoNames.S:
                    SShape s = new SShape();
                    WorkTetromino = s.NewTetr;
                    break;

                case (int)TetrominoNames.Z:
                    ZShape z = new ZShape();
                    WorkTetromino = z.NewTetr;
                    break;

                    ///ASK: Why it is not working?
                    //case (int)TetrominoNames.Z:
                    //    WorkTetromino = new ZShape().NewTetr;
                    //    break;
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

            for (int i = 0; i < WorkTetromino.Count; i++)
            {
                int newX = WorkTetromino[i].X * Convert.ToInt32(Math.Cos(angle)) - WorkTetromino[i].Y * Convert.ToInt32(Math.Sin(angle));
                int newY = WorkTetromino[i].X * Convert.ToInt32(Math.Sin(angle)) + WorkTetromino[i].Y * Convert.ToInt32(Math.Cos(angle));

                newTetromino.Add(new Point(newX, newY, WorkTetromino[i].Char));
            }

            switch (CheckCollision(newTetromino))
            {
                case true:
                    break;

                case false:
                    for (int i = 0; i < WorkTetromino.Count; i++)
                    {
                        WorkTetromino[i].Clear();
                    }

                    foreach (Point p in newTetromino)
                    {
                        p.DrawPoint();
                    }
                    WorkTetromino = newTetromino;
                    break;
            }
        }

        private bool CheckCollision(List<Point> checkingList)
        {
            bool answer = true;

            foreach (Point p in checkingList)
            {
                if (!(p.Char.Equals(null) || p.X > 0 || p.Y > 0))
                {
                    answer = true;
                }
                else
                    answer = false;
            }

            return answer;
        }
    }
}

