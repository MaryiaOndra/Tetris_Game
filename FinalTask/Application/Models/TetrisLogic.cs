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
        private List<Point> workShape;
        int angle = 90;

        public TetrisLogic()
        {
            SetRandomShape();
            RotateShape(angle);
        }

        private void SetRandomShape()
        {
            Random r = new Random();
            int numShape = r.Next(0, 6);

            switch (numShape)
            {
                case (int)TetrominoNames.O:
                    workShape = new OShape().NewShape;
                    break;
                case (int)TetrominoNames.I:
                    workShape = new ShapeI().NewShape;
                    break;
                case (int)TetrominoNames.J:
                    workShape = new JShape().NewShape;
                    break;
                case (int)TetrominoNames.T:
                    workShape = new TShape().NewShape;
                    break;
                case (int)TetrominoNames.L:
                    workShape = new LShape().NewShape;
                    break;
                case (int)TetrominoNames.S:
                    workShape = new SShape().NewShape;
                    break;
                case (int)TetrominoNames.Z:
                    workShape = new ZShape().NewShape;
                    break;
            }
        }

        private void MoveShape(List<Point> points)
        {

        }

        private void RotateShape(int angle)
        {
            List<Point> newBlock = new List<Point> { };

            for (int i = 0; i < workShape.Count; i++)
            {
                int newX = workShape[i].X * Convert.ToInt32(Math.Cos(angle)) - workShape[i].Y * Convert.ToInt32(Math.Sin(angle));
                int newY = workShape[i].X * Convert.ToInt32(Math.Sin(angle)) + workShape[i].Y * Convert.ToInt32(Math.Cos(angle));

                newBlock.Add(new Point(newX, newY, workShape[i].Char));
            }

            switch (IsNegative(newBlock) || IsPlaceBusy(newBlock))
            {
                case true:
                    break;

                case false:
                    for (int i = 0; i < workShape.Count; i++)
                    {
                        workShape[i].Clear();
                    }
                    workShape = newBlock;
                    break;
            }

            switch (IsPlaceBusy(newBlock))
            {
                default:
                    break;
            }
        }

        private bool IsNegative(List<Point> checkingList)
        {
            bool answer = true;

            foreach (Point p in checkingList)
            {
                if (!(p.X > 0 || p.Y > 0))
                {
                    answer = true;
                }
                else
                    answer = false;
            }

            return answer;
        }

        private bool IsPlaceBusy(List<Point> newCreatedList) 
        {
            bool answer = true;

            foreach (Point p in newCreatedList)
            {
                if (!p.Char.Equals(null))
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

